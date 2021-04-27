using Application.Auth;
using Microsoft.Extensions.Options;
using System;

namespace Tests.UnitTests.Login.Mocks
{
    public class TestOptionsMonitor : IOptionsMonitor<JwtConfig>
    {

        public JwtConfig CurrentValue { get; }

        public TestOptionsMonitor(JwtConfig currentValue)
        {
            CurrentValue = currentValue;
        }

        public JwtConfig Get(string name)
        {
            return CurrentValue;
        }

        public IDisposable OnChange(Action<JwtConfig, string> listener)
        {
            throw new NotImplementedException();
        }
    }
}
