using System;
using System.Linq;

public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private readonly Allergen PersonsAllergens;

    public Allergies(int mask) => PersonsAllergens = (Allergen)mask;

    public bool IsAllergicTo(Allergen allergen) => PersonsAllergens.HasFlag(allergen);

    public Allergen[] List() =>
        Enum.GetValues(typeof(Allergen))
            .Cast<Allergen>()
            .Where(x => PersonsAllergens.HasFlag(x))
            .ToArray();
}