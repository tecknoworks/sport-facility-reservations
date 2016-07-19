using System;

public class Class1
{
	public interface IUnitOfWork:IDisposable
	{
        IClientRepository Clients { get; }
        IFieldRepository Field { get; }
        int Complete();
	}
}
