namespace GhinImp;

// Record для хранения данных о персонаже

public record Character
{
    public string Name { get; }
    public string Element { get; }
    public int AttackPower { get; }
    private List<Skill> Skills { get; }

    public Character(string name, string element, int attackPower, List<Skill> skills)
    {
        Name = name;
        Element = element;
        AttackPower = attackPower;
        Skills = skills;
    }

    // Метод для проверки силы атаки
    public bool IsPowerful()
    {
        return AttackPower > 80;
    }
    
    public int CalculateTotalSkillDamage()
    {
        return Skills.Sum(skill => skill.CalculateSkillDamage());
    }
}