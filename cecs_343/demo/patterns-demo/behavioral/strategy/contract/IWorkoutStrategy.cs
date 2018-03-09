namespace patterns_demo.behavioral.strategy.contract
{
    /// <summary>
    /// Defines the contract for a workout strategy
    /// </summary>
    public interface IWorkoutStrategy : ICommand
    {
         // Additional members to further differentiate IWorkoutStrategy
         // from ICommand
         int TaskCount {get;}
    }
}