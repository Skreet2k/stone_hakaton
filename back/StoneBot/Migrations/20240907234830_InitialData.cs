using Microsoft.EntityFrameworkCore.Migrations;
using StoneBot.Domain;

#nullable disable

namespace StoneBot.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Skins",
                columns: new[]
                {
                    "Name",
                    "Price",
                    "Url",
                    "Discription",
                    "Slug"
                },
                values: new object[,]
                {
                    {
                        "Gem Fury",
                        4000,
                        "stones/fermer-4-450px.png",
                        "So angry, it can make other rocks lose their temper!",
                        "Slug"

                    },
                    {
                        "Fire Rock",
                        3000,
                        "stones/firestone-350px.png",
                        "Warning: This rock is hot! Perfect for campfire parties.",
                        "Slug"
                    },
                    {
                        "Golden Shine",
                        3500,
                        "stones/gold-1-350px.png",
                        "Shines so bright, you might need sunglasses. Visible from space!",
                        "Slug"
                    },
                    {
                        "Golden Spirit",
                        3700,
                        "stones/gold-2-350px.png",
                        "This rock has a golden soul... or maybe just a golden glow.",
                        "Slug"
                    },
                    {
                        "Gold Eye",
                        4500,
                        "stones/gold-3-350px.png",
                        "The eye of the treasure, always watching your fortune.",
                        "Slug"
                    },
                    {
                        "Gold Fox",
                        3900,
                        "stones/gold-4-350px.png",
                        "Sneaky and shiny, just like a fox with a gold coat.",
                        "Slug"
                    },
                    {
                        "Gray Rock",
                        2200,
                        "stones/gray-1-350px.png",
                        "Not much to look at, but it’s a solid friend. Literally.",
                        "Slug"
                    },
                    {
                        "Gray Stone",
                        2300,
                        "stones/gray-2-350px.png",
                        "As plain as it gets. But sometimes, plain is the new fancy!",
                        "Slug"
                    },
                    {
                        "Gray Gem",
                        2400,
                        "stones/gray-3-350px.png",
                        "This gem is so gray, even clouds envy it.",
                        "Slug"
                    },
                    {
                        "Gray Eye",
                        2500,
                        "stones/gray-4-350px.png",
                        "The eye that never blinks. Mostly because it’s a rock.",
                        "Slug"
                    },
                    {
                        "Gray Shimmer",
                        2600,
                        "stones/gray-5-350px.png",
                        "Shines with a soft gray hue. Subtle, yet charming.",
                        "Slug"
                    },
                    {
                        "Gray Glimmer",
                        2700,
                        "stones/gray-6-350px.png",
                        "Glimmers just enough to catch your eye, but not too much to blind you.",
                        "Slug"
                    },
                    {
                        "Gray Flash",
                        2800,
                        "stones/gray-7-350px.png",
                        "Flashes gray like a superhero with a dull costume.",
                        "Slug"
                    },
                    {
                        "Gray Slice",
                        2900,
                        "stones/gray-8-350px.png",
                        "A slice of the most exciting color in the rock world: gray!",
                        "Slug"
                    },
                    {
                        "Gray Pearl",
                        3000,
                        "stones/gray-9-350px.png",
                        "Looks like a pearl, but with 100% more grayness.",
                        "Slug"
                    },
                    {
                        "Mine Gem",
                        2100,
                        "stones/minestone-350px.png",
                        "This gem was found deep in the mines. Guaranteed to be mine-tastic!",
                        "Slug"
                    },
                    {
                        "Police Gem",
                        1900,
                        "stones/police-350px.png",
                        "Keeps all the other gems in check with its shiny authority.",
                        "Slug"
                    },
                    {
                        "Red Fury",
                        3100,
                        "stones/red-1-350px.png",
                        "Angrier than any other red rock you’ve ever seen.",
                        "Slug"
                    },
                    {
                        "Red Shine",
                        3300,
                        "stones/red-2-350px.png",
                        "Shines as bright as a sunset on a really good day.",
                        "Slug"
                    },
                    {
                        "Red Eye",
                        3500,
                        "stones/red-3-350px.png",
                        "The eye that burns with fiery red intensity. Don’t stare!",
                        "Slug"
                    },
                    {
                        "Red Fox",
                        3700,
                        "stones/red-4-350px.png",
                        "Swift, sly, and red – this rock is the fox of the gem world.",
                        "Slug"
                    },
                    {
                        "Red Gem",
                        3900,
                        "stones/red-5-350px.png",
                        "It’s so red, it makes roses jealous.",
                        "Slug"
                    },
                    {
                        "Stone Rock",
                        1800,
                        "stones/stone-1-350px.png",
                        "A rock that’s not afraid to be called what it is. Just stone.",
                        "Slug"
                    },
                    {
                        "Stone Gem",
                        2000,
                        "stones/stone-2-350px.png",
                        "This gem might be stony, but it’s still pretty valuable.",
                        "Slug"
                    },
                    {
                        "Stone Eye",
                        2200,
                        "stones/stone-3-350px.png",
                        "It sees everything... in a very stone-cold way.",
                        "Slug"
                    },
                    {
                        "Red Flag",
                        2500,
                        "stones/stone-redflag-350px.png",
                        "Waving a red flag in style. This rock is here to warn you!",
                        "Slug"
                    },
                    {
                        "Tooth Stone",
                        2700,
                        "stones/stonetooth-1-350px.png",
                        "Sharper than it looks, this stone could use some floss.",
                        "Slug"
                    },
                    {
                        "Tooth Gem",
                        2900,
                        "stones/stonetooth-2-350px.png",
                        "A gem with bite. Just be careful where you put it.",
                        "Slug"
                    },
                    {
                        "Turtle Stone",
                        2100,
                        "stones/turtle-350px.png",
                        "Slow and steady, but worth the wait.",
                        "Slug"
                    },
                    {
                        "White Gem",
                        3100,
                        "stones/white-350px.png",
                        "Pure as snow, and just as cold.",
                        "Slug"
                    },
                    {
                        "Dark Gem",
                        2000,
                        "stones/bdsm-350px.png",
                        "Not as dark as it sounds, but mysterious enough.",
                        "Slug"
                    },
                    {
                        "Circle Stone",
                        1900,
                        "stones/circle-stone350px.png",
                        "Round, simple, but endlessly fascinating.",
                        "Slug"
                    },
                    {
                        "Clown Stone",
                        2200,
                        "stones/clown-1-350px.png",
                        "This rock will make you laugh... or cry.",
                        "Slug"
                    },
                    {
                        "Clown Gem",
                        2300,
                        "stones/clown-2-350px.png",
                        "A gem that’s always ready for the circus.",
                        "Slug"
                    },
                    {
                        "Clown Eye",
                        2400,
                        "stones/clown-3-350px.png",
                        "It’s watching you... but in a funny way.",
                        "Slug"
                    },
                    {
                        "Clown Flag",
                        2500,
                        "stones/clown-4.5-350px.png",
                        "This flag waves with a joke in every breeze.",
                        "Slug"
                    },
                    {
                        "Clown Shine",
                        2600,
                        "stones/clown-4-350px.png",
                        "Shines with the brilliance of a clown’s best trick.",
                        "Slug"
                    },
                    {
                        "Clown Flash",
                        2700,
                        "stones/clown-5-350px.png",
                        "A quick flash of humor in every reflection.",
                        "Slug"
                    },
                    {
                        "Clown Pearl",
                        2800,
                        "stones/clown-6-350px.png",
                        "A rare pearl with a funny side.",
                        "Slug"
                    },
                    {
                        "Farm Gem",
                        2300,
                        "stones/fermer-1-350px.png",
                        "Grown straight from the fields of rock farming.",
                        "Slug"
                    },
                    {
                        "Farm Stone",
                        2400,
                        "stones/fermer-2-350px.png",
                        "Plucked fresh from the rocky soil. A real farm-to-table gem.",
                        "Slug"
                    },
                    {
                        "Farm Rock",
                        2500,
                        "stones/fermer-3-350px.png",
                        "The best crop of rocks this season.",
                        "Slug"
                    }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
