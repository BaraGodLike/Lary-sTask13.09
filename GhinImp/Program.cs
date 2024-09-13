using System.Collections.Concurrent;
using GhinImp;

var characterGroup = new CharacterGroup();

static void AddAllCharacters(CharacterGroup characterGroup)
{
    characterGroup.AddCharacter("Diluc", "Pyro", 100, new Skill("Searing Onslaught", 200));
    characterGroup.AddCharacter("Mona", "Hydro", 80, new Skill("Mirror Reflection of Doom", 150));
    characterGroup.AddCharacter("Venti", "Anemo", 70, new Skill ("Skyward Sonnet", 120));
}

static void PrintPowerFulCharacters(CharacterGroup characterGroup)
{
    var powerfulCharacters = characterGroup.FilterCharacters(c => c.IsPowerful());
    Console.WriteLine("Powerful Characters:");
    foreach (var character in powerfulCharacters)
        Console.WriteLine($"Character: {character.Name}, Attack Power: {character.AttackPower}");
}

Task mainTask = Task.Run(() => AddAllCharacters(characterGroup));
Task printPowerFulCharactersTask = Task.Run(() => PrintPowerFulCharacters(characterGroup));
Task printHighAttackersTask = Task.Run(() => PrintHighAttackers(characterGroup));
Task printSortedCharactersTask = Task.Run(() => PrintSortedCharacters(characterGroup));
Task numberOfPyroTask = Task.Run(() => Console.WriteLine($"Number of Pyro characters: {characterGroup.CountCharactersByElement("Pyro")}"));
Task strongestCharacterTask = Task.Run(() =>
    Console.WriteLine(
        $"\nStrongest Character: {characterGroup.GetStrongestCharacter().Name} with Attack Power: {characterGroup.GetStrongestCharacter().AttackPower}"));
Task findMona = Task.Run(() => FindMona(characterGroup));
mainTask.Start();
static void PrintHighAttackers(CharacterGroup characterGroup)
{
    var highAttackers = characterGroup.FilterCharacters(c => AttackCalculator.CalculateAverageAttack(c) > 80);

    foreach (var character in highAttackers)
    {
        Console.WriteLine(
            $"Character: {character.Name}, Average Attack: {AttackCalculator.CalculateAverageAttack(character):F2}");
    }
}

static void PrintSortedCharacters(CharacterGroup characterGroup)
{
    var sortedCharacters = characterGroup.SortCharactersByName;
    foreach (var character in sortedCharacters())
        Console.WriteLine($"Character: {character.Name}");
}

static void FindMona(CharacterGroup characterGroup)
{
    const string characterToFind = "Mona";
    var foundCharacter = characterGroup.FindCharacterByName(characterToFind);
    Console.WriteLine($"\nFound Character: {foundCharacter.Name} with Element: {foundCharacter.Element} and Attack Power: {foundCharacter.AttackPower}");
    Console.WriteLine($"Total Skill Damage: {foundCharacter.CalculateTotalSkillDamage()}");
}

// Используем метод GetStrongestCharacter для нахождения персонажа с наибольшей силой атаки


// Используем метод FindCharacterByName для поиска персонажа по имени

