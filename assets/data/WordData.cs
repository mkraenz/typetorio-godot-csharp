using System;
using System.Collections.Generic;

namespace Assets
{
    public partial class WordData
    {
        static Random rnd = new Random();
        public static readonly List<string> TheWords = new List<string>
        {
            "SMALL",
            "STRAIGHT",
            "MIXED",
            "STAR",
            "SQUEAL",
            "ATTACH",
            "SNOTTY",
            "HOLLOW",
            "SWIM",
            "DRAG",
            "GLOSSY",
            "PROPERTY",
            "BUTTON",
            "VICTORIOUS",
            "EIGHT",
            "FEW",
            "DEFIANT",
            "BEAR",
            "SHIVERING",
            "THRONE",
            "QUIVER",
            "TENUOUS",
            "STROKE",
            "SPACE",
            "LOVE",
            "TASTEFUL",
            "PEACE",
            "EDUCATION",
            "TANGIBLE",
            "ENCOURAGE",
            "CAPABLE",
            "UNPACK",
            "WATER",
            "TICK",
            "SYMPTOMATIC",
            "ATTRACTION",
            "TRITE",
            "ILLUSTRIOUS",
            "DAMP",
            "WISH",
            "POPCORN",
            "CARVE",
            "AHEAD",
            "STEEP",
            "ADMIT",
            "STRUCTURE",
            "CONCERNED",
            "SHAME",
            "VEGETABLE",
            "CHANNEL",
            "HIGH",
            "YAM",
            "TABOO",
            "GIDDY",
            "THUMB",
            "THRILL",
            "KNOWLEDGE",
            "WORD",
            "ALERT",
            "SEASHORE",
            "ETHEREAL",
            "SERVANT",
            "UNBECOMING",
            "DEGREE",
            "FINICKY",
            "KITTENS",
            "MILITARY",
            "RAGGED",
            "PLACE",
            "BEHAVIOR",
            "POISON",
            "WATCH",
            "OBJECT",
            "FAX",
            "JOG",
            "SHAKY",
            "TREATMENT",
            "NEIGHBORLY",
            "SALT",
            "SCOLD",
            "INSIDIOUS",
            "WIPE",
            "DROP",
            "OAFISH",
            "PALTRY",
            "TREES",
            "SLOPE",
            "OBSCENE",
            "AGREEMENT",
            "NOTE",
            "JEALOUS",
            "MASS",
            "BOX",
            "RIGID",
            "FEMALE",
            "BEAUTIFUL",
            "ENJOY",
            "PERIODIC",
            "BLUSHING",
            "REFLECT",
            "SCRATCH",
            "PREPARE",
            "FOOLISH",
            "BLIND",
            "WREN",
            "SPITEFUL",
            "MEAN",
            "WRECK",
            "RUN",
            "DISAGREEABLE",
            "SNAKE",
            "STOCKING",
            "SUN",
            "WIND",
            "DEPRESSED",
            "SHUT",
            "GAZE",
            "SQUEAMISH",
            "VANISH",
            "LACKING",
            "TERRIFY",
            "HUMOR",
            "EVENT",
            "RELIGION",
            "CHEER",
            "UNRULY",
            "RAIN",
            "PRICKLY",
            "KILL",
            "DISCREET",
            "IMPRESS",
            "COMMUNICATE",
            "WHITE",
            "GOOD",
            "SHOCKING",
            "SKIRT",
            "FROG",
            "DELAY",
            "REMINISCENT",
            "HARMONIOUS",
            "BIKES",
            "HARM",
            "TANGY",
            "LUMBER",
            "BOARD",
            "FUNCTIONAL",
            "BASIN",
            "FLUFFY",
            "WOMAN",
            "COMPANY",
            "INFAMOUS",
            "LIVE",
            "RELATION",
            "SMOKE",
            "BAIT",
            "IMPORTANT",
            "LOOSE",
            "HANDY",
            "CLAIM",
            "BULB",
            "SWANKY",
            "INCONCLUSIVE",
            "STAKING",
            "BANG",
            "BURLY",
            "SHY",
            "PORTER",
            "DOUBT",
            "UNBIASED",
            "ITCHY",
            "ANALYZE",
            "UTOPIAN",
            "HEAVENLY",
            "NARROW",
            "AJAR",
            "PLEASURE",
            "EXCELLENT",
            "KNOWN",
            "GLASS",
            "REMAIN",
            "BEWILDERED",
            "WIDE",
            "HORSES",
            "MORNING",
            "ITCH",
            "AMBIGUOUS",
            "ELDERLY",
            "PRESS",
            "GIFTED",
            "MUDDLE",
            "IGNORANT",
            "RECONDITE",
            "TERRIFIC",
            "MACHO",
            "TASTELESS",
            "LUNCHROOM",
            "SQUEEZE",
            "DISCUSSION",
            "SYNONYMOUS",
            "RELEASE",
            "GRANDIOSE",
            "SUBSTANCE",
            "SAND",
            "COORDINATED",
            "UNKEMPT",
            "TOP",
            "READING",
            "LIMPING",
            "DISPENSABLE",
            "FENCE",
            "PECK",
            "FLIPPANT",
            "RANGE",
            "THREE",
            "SORT",
            "FLOOR",
            "RACE",
            "STOP",
            "EQUAL",
            "QUILL",
            "SWITCH",
            "CLAP",
            "SISTER",
            "PIES",
            "SOLID",
            "CURL",
            "SAFE",
            "IRON",
            "FRAIL",
            "MOAN",
            "CHEERFUL",
            "KINDLY",
            "PURRING",
            "FORM",
            "PAYMENT",
            "STRANGER",
            "SLIM",
            "OCEAN",
            "PLANTATION",
            "NOSTALGIC",
            "FLOWER",
            "TIGER",
            "RAPID",
            "UNACCOUNTABLE",
            "DUST",
            "ECONOMIC",
            "HOSPITABLE",
            "HAPPY",
            "SUSPEND",
            "UNABLE",
            "COUNTRY",
            "OBSEQUIOUS",
            "SWEATER",
            "SUPREME",
            "OVERJOYED",
            "CHILLY",
            "GHOST",
            "OPTIMAL",
            "CARPENTER",
            "SPARE",
            "PLOT",
            "FUNNY",
            "BORDER",
            "BOOK",
            "DESERTED",
            "TRAMP",
            "CROW",
            "ABSORBED",
            "LUMPY",
            "MOTION",
            "FILM",
            "DREARY",
            "COURAGEOUS",
            "WIRY",
            "REGRET",
            "IGNORE",
            "ORANGE",
            "LAVISH",
            "FURNITURE",
            "MAN",
            "PSYCHEDELIC",
            "RIGHT",
            "MINDLESS",
            "DRIVING",
            "WEATHER",
            "PUMP",
            "CARELESS",
            "MANAGE",
            "GROTESQUE",
            "SETTLE",
            "PRECIOUS",
            "LIP",
            "MARKET",
            "BITE",
            "SLIPPERY",
            "VEST",
            "DUCK",
            "HOUSE",
            "RUDE",
            "HOP",
            "TACKY",
            "STEADY",
            "HOME",
            "POSSESSIVE",
            "POWDER",
            "TOWERING",
            "EXCITED",
            "SNAKES",
            "VOLLEYBALL",
            "FOUR",
            "TOOTH",
            "RING",
            "VALUABLE",
            "CAUSE",
            "COLOR",
            "WASH",
            "STEAM",
            "GATE",
            "SCENE",
            "PAINT",
            "MOON",
            "GIRAFFE",
            "DIGESTION",
            "STRING",
            "DAMAGING",
            "FLAG",
            "AMUSING",
            "THREAD",
            "EXPERIENCE",
            "HUGE",
            "GIANT",
            "AFTERTHOUGHT",
            "PARALLEL",
            "INTELLIGENT",
            "DIRECTION",
            "SWING",
            "IMPOSSIBLE",
            "UNSIGHTLY",
            "DARE",
            "SOMBER",
            "GLISTENING",
            "PROUD",
            "CHEESE",
            "KNOTTY",
            "ACCEPTABLE",
            "JUICE",
            "SOGGY",
            "RINSE",
            "FRIGHTENED",
            "PETITE",
            "SHAPE",
            "LETHAL",
            "SILLY",
            "INSTINCTIVE",
            "INCREASE",
            "WOOL",
            "SECRETIVE",
            "SILENT",
            "EYES",
            "DISTURBED",
            "EDGE",
            "PIG",
            "EXPLAIN",
            "UNTIDY",
            "CAP",
            "SEARCH",
            "ENERGETIC",
            "LAMENTABLE",
            "FEARLESS",
            "CRATE",
            "VISITOR",
            "SPILL",
            "COWS",
            "ABOUNDING",
            "ABUSIVE",
            "MELTED",
            "OUTGOING",
            "GLOW",
            "MASSIVE",
            "DETERMINED",
            "DIFFERENT",
            "STEER",
            "ULTRA",
            "ROMANTIC",
            "PRICEY",
            "TIRE",
            "GABBY",
            "SCRAPE",
            "SKINNY",
            "CHIN",
            "BRUISE",
            "GREAT",
            "COPPER",
            "SLIP",
            "ALARM",
            "PARSIMONIOUS",
            "NERVE",
            "AGGRESSIVE",
            "SHAVE",
            "EVEN",
            "PARTY",
            "SABLE",
            "HALF",
            "ROOT",
            "FOOL",
            "UBIQUITOUS",
            "PANICKY",
            "PERMIT",
            "RELIEVED",
            "TAN",
            "DIME",
            "TIRESOME",
            "EATABLE",
            "TRUCKS",
            "NICE",
            "ARRANGE",
            "SEAL",
            "FINGER",
            "NOISE",
            "CRAYON",
            "POISED",
            "SUMMER",
            "COMPLEX",
            "MAKESHIFT",
            "EMBARRASSED",
            "SHEET",
            "COW",
            "CONNECTION",
            "CART",
            "COLD",
            "WRIGGLE",
            "QUEUE",
            "DECORATE",
            "COOL",
            "TRAIN",
            "BENEFICIAL",
            "STEM",
            "HONEY",
            "DOMINEERING",
            "ARREST",
            "NOTICE",
            "GUILTLESS",
            "LEFT",
            "USED",
            "THOUGHTFUL",
            "GRAB",
            "RUSH",
            "FESTIVE",
            "MISS",
            "HELPLESS",
            "AWAKE",
            "MAILBOX",
            "GUARD",
            "TALK",
            "REPORT",
            "SCIENTIFIC",
            "CHICKENS",
            "DRY",
            "PROVIDE",
            "SHORT",
            "FREE",
            "EXCHANGE",
            "SMASH",
            "RED",
            "CLEAN",
            "SNEAKY",
            "FIREMAN",
            "CORRECT",
            "INEXPENSIVE",
            "POLLUTION",
            "MAID",
            "SMELL",
            "COMPARE",
            "PET",
            "NONSTOP",
            "ACTOR",
            "DUCKS",
            "PLASTIC",
            "TROT",
            "EXCITE",
            "THIRD",
            "FAIR",
            "GRATE",
            "DRUNK",
            "RESPECT",
            "FORGETFUL",
            "CRAVEN",
            "REPLACE",
            "SUBSTANTIAL",
            "PANCAKE",
            "BAD",
            "CROSS",
            "WOEBEGONE",
            "PROGRAM",
            "ELFIN",
            "SCREAM",
            "ABASHED"
        };

        public static string GetRandomWord()
        {
            int index = rnd.Next(TheWords.Count);
            return TheWords[index];
        }
    }
}
