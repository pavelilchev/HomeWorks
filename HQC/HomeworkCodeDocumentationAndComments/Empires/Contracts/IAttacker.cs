namespace Empires.Contracts
{
    /// <summary>
    /// Provide attack behavior.
    /// </summary>
    public interface IAttacker
    {
        /// <summary>
        /// Gets attack damage.
        /// </summary>
        int AttackDamage { get; }
    }
}
