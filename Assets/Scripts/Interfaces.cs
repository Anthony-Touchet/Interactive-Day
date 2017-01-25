// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Interfaces.cs" company="Anthony">
//   CODE HAR EVERY DAY
// </copyright>
// <summary>
//   Defines the IDamager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Assets.Scripts
{
    public interface IDamager
    {
        int Damage { get; set; }
    }

    public interface IDamagable
    {
        int Health { get; set; }

        void TakeDamage(int dam);
    }
}