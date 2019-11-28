using Stateless;

namespace StatelessDapperSample.Domain.ValueObj
{
    public static class StatusConfiguration
    {
        public static void Build(StateMachine<StatusEnum, TriggerEnum> machine)
        {
            machine.Configure(StatusEnum.Initial)
                .Permit(TriggerEnum.NormalPath, StatusEnum.Wait)
                .Permit(TriggerEnum.Blocked, StatusEnum.Blocked);

            machine.Configure(StatusEnum.Wait)
                .Permit(TriggerEnum.Success, StatusEnum.Registered)
                .Permit(TriggerEnum.Error, StatusEnum.Error)
                .Permit(TriggerEnum.Retry, StatusEnum.Retry);

            machine.Configure(StatusEnum.Blocked)
                .Permit(TriggerEnum.Enqueue, StatusEnum.Wait);

            machine.Configure(StatusEnum.Error)
                .Permit(TriggerEnum.Archive, StatusEnum.Archived)
                .Permit(TriggerEnum.Retry, StatusEnum.Retry);

            machine.Configure(StatusEnum.Retry)
                .Permit(TriggerEnum.Success, StatusEnum.Registered)
                .Permit(TriggerEnum.Error, StatusEnum.Error);
        }

    }
}
