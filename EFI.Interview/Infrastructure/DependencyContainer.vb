Public Class DependencyContainer
    Private dependencies As IDictionary(Of Type, Func(Of Object))

    Public Sub Bind(Of TContract As Class, TImplementation As TContract)(ByVal factory As Func(Of TImplementation))
        Me.dependencies.Add(GetType(TContract), New Func(Of Object)(Function() factory()))
    End Sub

    Public Function [Get](Of TContract As Class)() As TContract
        If dependencies.ContainsKey(GetType(TContract)) Then
            Return TryCast(dependencies(GetType(TContract))(), TContract)
        Else
            Throw New KeyNotFoundException("The given type was not registered with the container")
        End If

    End Function

    Public Sub New()
        Me.dependencies = New Dictionary(Of Type, Func(Of Object))
    End Sub

    Private Shared defaultInstance As DependencyContainer

    Public Shared ReadOnly Property [Default] As DependencyContainer
        Get
            Return defaultInstance
        End Get
    End Property

    Shared Sub New()
        defaultInstance = New DependencyContainer
    End Sub
End Class
