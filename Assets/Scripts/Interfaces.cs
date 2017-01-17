// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Interfaces.cs" company="Anthony">
//   CODE HARD EVERY DAY
// </copyright>
// <summary>
//   
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
    }
}