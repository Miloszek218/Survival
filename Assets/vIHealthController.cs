using Invector;

public partial class TigerAi
{
    public TigerAi()
    {
    }

    public interface vIHealthController : vIDamageReceiver
    {
        OnDead onDead { get; }
        float currentHealth { get; }
        int MaxHealth { get; }
        bool isDead { get; set; }
        void ChangeHealth(int value);
        void ChangeMaxHealth(int value);
    }
                return;

        }
    }
}
