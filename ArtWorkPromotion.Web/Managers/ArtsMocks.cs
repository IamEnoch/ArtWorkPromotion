public static class ArtMocks
{
    public static List<Art> GetArts()
    {
        return new List<Art> {
            new Art {
               Name = "Wallowing Breeze",
               Description = "Hettie Richards"
            }, new Art {
               Name = "J Resistance",
               Description = "Gouache on paper, 2018"
            }, new Art {
               Name = "Warm Basket",
               Description = "Acrylic on wood, 2014"
            }, new Art {
               Name = "Warm Basket",
               Description = "Flora Powers"
            }, new Art {
               Name = "The Vonnegut ",
               Description = "Oil on canvas, 2018"
            }
        };
    }
}