Imports System.Reflection
Imports System.Runtime.CompilerServices

    ''' <summary>
    ''' Contains methods that extend the <see cref="IEnumerable(Of T)"/> interface.
    ''' </summary>
    Public Module EnumerableExtensions

        ''' <summary>
        ''' Returns a <see cref="DataTable"/> containing the data from the source list.
        ''' </summary>
        ''' <typeparam name="T">
        ''' The type of the list items.
        ''' </typeparam>
        ''' <param name="source">
        ''' The source list.
        ''' </param>
        ''' <returns>
        ''' A <see cref="DataTable"/> with a column for each public property in the item type and a row for each item.
        ''' </returns>
        <Extension>
        Public Function ToDataTable(Of T)(source As IEnumerable(Of T)) As DataTable
            Dim sourceType = GetType(T)
            Dim properties = sourceType.GetProperties()
            Dim table As New DataTable

            'Add a column for each public instance property of the items.
            For Each prop In properties
                table.Columns.Add(prop.Name,
                                  If(Nullable.GetUnderlyingType(prop.PropertyType),
                                     prop.PropertyType))
            Next

            'Add a row for each item.
            For Each item In source
                Dim row = table.NewRow()

                row.BeginEdit()

                For Each prop In properties
                    row(prop.Name) = If(prop.GetValue(item), DBNull.Value)
                Next

                row.EndEdit()

                table.Rows.Add(row)
            Next

            Return table
        End Function

    End Module
