Imports System.Data.Sql
Imports System.Data.SqlClient


Public Class SPSCCDatasetClass
    Inherits DataSet
    Private _filename As String
    Private Const DEFAULT_FILE_NAME As String = "SPSCCdb_BEverson.mdf"
    Private Const CONNECTION_LOCATION_STRING As String =
        "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\{0};Integrated Security=True"

    Private Const COURSES_SELECT_STATEMENT As String =
        "SELECT crs_autCourse, crs_txtDept, crs_txtNumber, crs_txtTitle, crs_bytCredits FROM tblCourses"

    Private CoursesTableIndex As Integer
    Private Const COURSES_TABLE_NAME As String = "Courses"
    Public ReadOnly Property Courses As DataTable
        Get
            Return Me.Tables.Item(CoursesTableIndex)
        End Get
    End Property

    Private Const SECTIONS_SELECT_STATEMENT As String =
        "SELECT sec_autSectionID, sec_txtQuarter, sec_txtItem, sec_lngCourse, sec_txtDays, " &
        "sec_dtmStart, sec_dtmEnd, sec_txtRoom, sec_txtInstructor FROM  tblSections"

    Private SectionsTableIndex As Integer
    Private Const SECTIONS_TABLE_NAME = "Sections"
    Public ReadOnly Property Sections As DataTable
        Get
            Return Me.Tables.Item(SectionsTableIndex)
        End Get
    End Property

    Private Const STUDENTS_SELECT_STATEMENT As String =
        "SELECT stu_txtStudentID, stu_txtFirstName, stu_txtLastName, stu_txtFirstName + ' ' + stu_txtLastName AS FullName FROM tblStudents"

    Private StudentsTableIndex As Integer
    Private Const STUDENTS_TABLE_NAME As String = "Students"

    Public ReadOnly Property Students As DataTable
        Get
            Return Me.Tables.Item(StudentsTableIndex)
        End Get
    End Property


    Private EnrollmentsTableIndex As Integer
    Private Const ENROLLMENTS_SELECT_STATEMENT As String =
        "SELECT enr_txtStudent, enr_lngSection from tblEnrollments"

    Private Const ENROLLMENTS_TABLE_NAME As String = "Enrollments"
    Public ReadOnly Property Enrollments As DataTable
        Get
            Return Me.Tables.Item(EnrollmentsTableIndex)
        End Get
    End Property

    Private ReadOnly Property ConnectionString As String
        Get
            Return String.Format(CONNECTION_LOCATION_STRING, FileName)
        End Get
    End Property

    Public ReadOnly Property FileName As String
        Get
            Return _filename
        End Get
    End Property

    Public Sub New()
        _filename = DEFAULT_FILE_NAME
        LoadDataSet()
    End Sub

    Private loaded As Boolean = False

    Private Sub LoadDataSet()
        'clear relations and tables
        ClearDataSet()

        'fill courses, then sectinos, then students, then enrollments
        CoursesTableIndex = FillTable(COURSES_SELECT_STATEMENT, COURSES_TABLE_NAME)
        SectionsTableIndex = FillTable(SECTIONS_SELECT_STATEMENT, SECTIONS_TABLE_NAME)
        StudentsTableIndex = FillTable(STUDENTS_SELECT_STATEMENT, STUDENTS_TABLE_NAME)
        EnrollmentsTableIndex = FillTable(ENROLLMENTS_SELECT_STATEMENT, ENROLLMENTS_TABLE_NAME)

        'add primary keys
        AddPrimaryKey(Courses, Courses.Columns.Item(0))
        AddPrimaryKey(Sections, Sections.Columns.Item(0))
        AddPrimaryKey(Students, Students.Columns.Item(0))
        Dim EnrollmentsPK() As DataColumn = {Enrollments.Columns.Item(0), Enrollments.Columns.Item(1)}
        AddPrimaryKey(Enrollments, EnrollmentsPK)

        'Add data relations
        AddRelation(Courses, Sections, 3)
        AddRelation(Sections, Enrollments, 1)
        AddRelation(Students, Enrollments, 0)
        loaded = True
    End Sub

    Private Sub ClearDataSet()
        Relations.Clear()
        If (loaded) Then
            Enrollments.Constraints.Clear()
            Sections.Constraints.Clear()
            Students.Constraints.Clear()
            Courses.Constraints.Clear()
            Tables.Clear()
        End If
    End Sub


    'This event is used to notify other classes
    Public Event Saved(sender As Object, e As EventArgs)

    Public Sub Onsaved(e As EventArgs)
        RaiseEvent Saved(Me, e)
    End Sub


    Public Sub Save()
        'Save updated courses, then sections, then students, then enrollments
        DataServices.SaveRows(FileName, COURSES_SELECT_STATEMENT, GetDataRows(Courses, DataRowState.Modified))
        DataServices.SaveRows(FileName, SECTIONS_SELECT_STATEMENT, GetDataRows(Sections, DataRowState.Modified))
        DataServices.SaveRows(FileName, STUDENTS_SELECT_STATEMENT, GetDataRows(Students, DataRowState.Modified))
        DataServices.SaveRows(FileName, ENROLLMENTS_SELECT_STATEMENT, GetDataRows(Enrollments, DataRowState.Modified))


        'Save inserted courses, then sections, then students, then enrollments
        DataServices.SaveRows(FileName, COURSES_SELECT_STATEMENT, GetDataRows(Courses, DataRowState.Added))
        DataServices.SaveRows(FileName, SECTIONS_SELECT_STATEMENT, GetDataRows(Sections, DataRowState.Added))
        DataServices.SaveRows(FileName, STUDENTS_SELECT_STATEMENT, GetDataRows(Students, DataRowState.Added))
        DataServices.SaveRows(FileName, ENROLLMENTS_SELECT_STATEMENT, GetDataRows(Enrollments, DataRowState.Added))

        'Save deleted enrollments, students, sections, then courses
        DataServices.SaveRows(FileName, ENROLLMENTS_SELECT_STATEMENT, GetDataRows(Enrollments, DataRowState.Deleted))
        DataServices.SaveRows(FileName, STUDENTS_SELECT_STATEMENT, GetDataRows(Students, DataRowState.Deleted))
        DataServices.SaveRows(FileName, SECTIONS_SELECT_STATEMENT, GetDataRows(Sections, DataRowState.Deleted))
        DataServices.SaveRows(FileName, COURSES_SELECT_STATEMENT, GetDataRows(Courses, DataRowState.Deleted))

        Onsaved(EventArgs.Empty)

        'reload dataset
        LoadDataSet()
    End Sub

    Private Function FillTable(selectStatement As String, tableName As String) As Integer
        Dim dt As DataTable = DataServices.GetTable(FileName, selectStatement, tableName)

        'Add table to dataset tables collection and return index of table
        Tables.Add(dt)
        Return Tables.IndexOf(dt)
    End Function

    Public Function GetDataRows(table As DataTable, state As DataRowState) As DataRow()
        'create a collection of datarows
        Dim rows As New List(Of DataRow)()
        For Each tableRow As DataRow In table.Rows
            'if row is in state, add to collection
            If tableRow.RowState = state Then
                rows.Add(tableRow)
            End If
        Next

        Return rows.ToArray()
    End Function

    Private Sub AddPrimaryKey(table As DataTable, column As DataColumn)
        Dim dc(1) As DataColumn
        dc(0) = column
        table.PrimaryKey = dc
    End Sub

    Private Sub AddPrimaryKey(table As DataTable, columns() As DataColumn)
        table.PrimaryKey = columns
    End Sub

    Private Sub AddRelation(parent As DataTable, child As DataTable, childColumnIndex As Integer)
        'create relation name based on child table name and parent table name
        Dim relationName As String = String.Format("FK_{0}_{1}", child.TableName, parent.TableName)
        Dim PrimaryKey(0) As DataColumn
        Dim ForeignKey(0) As DataColumn

        PrimaryKey(0) = New DataColumn()
        ForeignKey(0) = New DataColumn()

        'Set primary key and foreign key datacolumn array
        PrimaryKey = parent.PrimaryKey
        ForeignKey(0) = child.Columns.Item(childColumnIndex)

        'Create and add data relation
        Dim dr As DataRelation = New DataRelation(relationName, PrimaryKey, ForeignKey)
        Relations.Add(dr)
    End Sub
End Class
