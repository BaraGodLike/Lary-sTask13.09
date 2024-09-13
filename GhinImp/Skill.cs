namespace GhinImp;

// Класс для описания навыков персонажей
public class Skill(string skillName, int dmg)
{
    public string SkillName { get; } = skillName;
    private int Damage { get; } = dmg;

    public Skill() : this("Unnamed Skill", 0)
    {
    }

    // Метод для расчета урона навыка
    public int CalculateSkillDamage()
    {
        return Damage * 2;
    }
}