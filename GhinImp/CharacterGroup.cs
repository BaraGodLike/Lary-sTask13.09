namespace GhinImp;

// Класс для управления группой персонажей
public class CharacterGroup
{
    private List<Character> Characters { get; } = new();

    // Метод для добавления персонажей
    public void AddCharacter(string name, string element, int attackPower, params Skill[] skills)
    {
        Characters.Add(new Character(name, element, attackPower, skills.ToList()));
    }

    // Метод для фильтрации персонажей по критерию
    public IEnumerable<Character> FilterCharacters(Func<Character, bool> criteria)
    {
        return Characters.Where(criteria);
    }

    // Метод для сортировки персонажей по имени
    public IEnumerable<Character> SortCharactersByName()
    {
        return Characters.OrderByDescending(c => c.Name);
    }

    // Метод для подсчета количества персонажей определенного элемента
    public int CountCharactersByElement(string element)
    {
        return Characters.Count(c => c.Element == element);
    }

    // Метод для получения персонажа с наибольшей атакой
    public Character GetStrongestCharacter()
    {
        return Characters.MaxBy(c => c.AttackPower)!;
    }

    // Метод для поиска персонажа по имени
    public Character FindCharacterByName(string name)
    {
        return Characters.FirstOrDefault(c => c.Name == name)!;
    }
}