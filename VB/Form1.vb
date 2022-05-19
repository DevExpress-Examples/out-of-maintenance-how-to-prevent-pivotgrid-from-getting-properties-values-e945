Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections

Namespace Q135913

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
            Dim fakeDataSource As List(Of DataObject) = New List(Of DataObject)()
            fakeDataSource.Add(New DataObject())
            pivotGridControl1.DataSource = New DataSourceWrapper(ReportType.Report1, fakeDataSource)
            pivotGridControl1.RetrieveFields()
            pivotGridControl2.DataSource = New DataSourceWrapper(ReportType.Report2, fakeDataSource)
            pivotGridControl2.RetrieveFields()
        End Sub
    End Class

    Public Class DataObject

        Public ReadOnly Property A As String
            Get
                Return "A"
            End Get
        End Property

        Public ReadOnly Property B As String
            Get
                Return "B"
            End Get
        End Property
    End Class

    Public Enum ReportType
        Report1
        Report2
    End Enum

    Public Class DataSourceWrapper
        Implements ITypedList, IList

        Private ReadOnly rtype As ReportType

        Private ReadOnly dataSource As IList

        Public Sub New(ByVal rtype As ReportType, ByVal dataSource As IList)
            Me.rtype = rtype
            Me.dataSource = dataSource
        End Sub

#Region "ITypedList Members"
        Private Function GetItemProperties(ByVal listAccessors As PropertyDescriptor()) As PropertyDescriptorCollection Implements ITypedList.GetItemProperties
            Dim props As PropertyDescriptorCollection = Nothing
            Dim srcTypedList As ITypedList = TryCast(dataSource, ITypedList)
            If srcTypedList IsNot Nothing Then props = srcTypedList.GetItemProperties(listAccessors)
            If dataSource.Count > 0 Then props = TypeDescriptor.GetProperties(dataSource(0))
            If props Is Nothing Then Return Nothing
            Dim res As List(Of PropertyDescriptor) = New List(Of PropertyDescriptor)()
            Select Case rtype
                Case ReportType.Report1
                    res.Add(props("A"))
                Case ReportType.Report2
                    res.Add(props("B"))
            End Select

            Return New PropertyDescriptorCollection(res.ToArray())
        End Function

        Private Function GetListName(ByVal listAccessors As PropertyDescriptor()) As String Implements ITypedList.GetListName
            Return [GetType]().Name
        End Function

#End Region
#Region "IList Members"
        Public Function Add(ByVal value As Object) As Integer Implements IList.Add
            Return dataSource.Add(value)
        End Function

        Public Sub Clear() Implements IList.Clear
            dataSource.Clear()
        End Sub

        Public Function Contains(ByVal value As Object) As Boolean Implements IList.Contains
            Return dataSource.Contains(value)
        End Function

        Public Function IndexOf(ByVal value As Object) As Integer Implements IList.IndexOf
            Return dataSource.IndexOf(value)
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As Object) Implements IList.Insert
            dataSource.Insert(index, value)
        End Sub

        Public ReadOnly Property IsFixedSize As Boolean Implements IList.IsFixedSize
            Get
                Return dataSource.IsFixedSize
            End Get
        End Property

        Public ReadOnly Property IsReadOnly As Boolean Implements IList.IsReadOnly
            Get
                Return dataSource.IsReadOnly
            End Get
        End Property

        Public Sub Remove(ByVal value As Object) Implements IList.Remove
            dataSource.Remove(value)
        End Sub

        Public Sub RemoveAt(ByVal index As Integer) Implements IList.RemoveAt
            dataSource.RemoveAt(index)
        End Sub

        Default Public Property Item(ByVal index As Integer) As Object Implements IList.Item
            Get
                Return dataSource(index)
            End Get

            Set(ByVal value As Object)
                dataSource(index) = value
            End Set
        End Property

#End Region
#Region "ICollection Members"
        Public Sub CopyTo(ByVal array As Array, ByVal index As Integer) Implements ICollection.CopyTo
            dataSource.CopyTo(array, index)
        End Sub

        Public ReadOnly Property Count As Integer Implements ICollection.Count
            Get
                Return dataSource.Count
            End Get
        End Property

        Public ReadOnly Property IsSynchronized As Boolean Implements ICollection.IsSynchronized
            Get
                Return dataSource.IsSynchronized
            End Get
        End Property

        Public ReadOnly Property SyncRoot As Object Implements ICollection.SyncRoot
            Get
                Return dataSource.SyncRoot
            End Get
        End Property

#End Region
#Region "IEnumerable Members"
        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return dataSource.GetEnumerator()
        End Function
#End Region
    End Class
End Namespace
