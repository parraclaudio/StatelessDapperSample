using Stateless;
using StatelessDapperSample.Domain.ValueObj;
using System;

namespace StatelessDapperSample.Domain.Data
{
    public class SampleData
    {
        public int Id { get; set; }

        public StatusEnum Status = StatusEnum.Initial;

        public StateMachine<StatusEnum, TriggerEnum> _machine;

        public SampleData()
        {
            _machine = new StateMachine<StatusEnum, TriggerEnum>(() => Status, s => Status = s);
            StatusConfiguration.Build(_machine);
        }
    }
}
