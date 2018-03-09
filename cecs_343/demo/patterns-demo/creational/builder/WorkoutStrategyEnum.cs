
// Note: Moving WorkoutStrategyEnum to the higher namespace since both contract and 
// implementation requires it.  This avoids cyclical dependencies
namespace patterns_demo.creational.builder
{
    /// <summary>
    /// Enumeration of Workout Strategies
    /// </summary>
    public enum WorkoutStrategyEnum
    {
        Normal = 0, // Default
        LegDay = 1
    }
}