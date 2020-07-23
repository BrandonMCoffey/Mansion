using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class PlayerClass
{
    public string Name { get; set; }
    public string Color { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Height { get; set; }
    public int Weight { get; set; }
    public string Birthday { get; set; }
    public string Hobbies { get; set; }
    public string Description { get; set; }
    public string Fears { get; set; }
    public int SpeedLevel { get; set; }
    public int[] Speed { get; set; }
    public int MightLevel { get; set; }
    public int[] Might { get; set; }
    public int SanityLevel { get; set; }
    public int[] Sanity { get; set; }
    public int KnowledgeLevel { get; set; }
    public int[] Knowledge { get; set; }
}

public class Blank : PlayerClass
{
    public Blank()
    {
        Name = "Choose Character";
        Color = "N/A";
        Age = 0;
        Gender = "N/A";
        Height = "N/A";
        Weight = 0;
        Birthday = "N/A";
        Hobbies = "N/A";
        Description = "N/A.";
        Fears = "N/A";
        SpeedLevel = 4;
        Speed = new int[] {
            0, 1, 2, 3, 4, 5, 6, 7, 8
        };
        MightLevel = 4;
        Might = new int[] {
            0, 1, 2, 3, 4, 5, 6, 7, 8
        };
        SanityLevel = 4;
        Sanity = new int[] {
            0, 1, 2, 3, 4, 5, 6, 7, 8
        };
        KnowledgeLevel = 4;
        Knowledge = new int[] {
            0, 1, 2, 3, 4, 5, 6, 7, 8
        };
    }
}
public class Missy : PlayerClass
{
    public Missy()
    {
        Name = "Missy Dubourde";
        Color = "Yellow";
        Age = 9;
        Gender = "Female";
        Height = "4'2\"";
        Weight = 62;
        Birthday = "Febuary 14th";
        Hobbies = "Swimming, Medicine";
        Description = "A creepy little girl, who wants to be a doctor. She cuts up dead things, for fun. Missy then has nightmares about them.";
        Fears = "Dead things coming back to life to haunt her.";
        SpeedLevel = 3;
        Speed = new int[] {
            0, 3, 4, 5, 6, 6, 6, 7, 7
        };
        MightLevel = 4;
        Might = new int[] {
            0, 2, 3, 3, 3, 4, 5, 6, 7
        };
        SanityLevel = 3;
        Sanity = new int[] {
            0, 1, 2, 3, 4, 5, 5, 6, 7
        };
        KnowledgeLevel = 4;
        Knowledge = new int[] {
            0, 2, 3, 4, 4, 5, 6, 6, 6
        };
    }
}
public class Zoe : PlayerClass
{
    public Zoe()
    {
        Name = "Zoe";
        Color = "Yellow";
        Age = 8;
        Gender = "Female";
        Height = "3'9\"";
        Weight = 49;
        Birthday = "November 5th";
        Hobbies = "Dolls, Music";
        Description = "Zoe has an implied tragic story. Raised in an unhappy home, she uses dolls to express her emotions.";
        Fears = "The Boogeyman.";
        SpeedLevel = 4;
        Speed = new int[] {
            0, 4, 4, 4, 4, 5, 6, 8, 8
        };
        MightLevel = 4;
        Might = new int[] {
            0, 2, 2, 3, 3, 4, 4, 6, 7
        };
        SanityLevel = 3;
        Sanity = new int[] {
            0, 3, 4, 5, 5, 6, 6, 7, 8
        };
        KnowledgeLevel = 3;
        Knowledge = new int[] {
            0, 1, 2, 3, 4, 4, 5, 5, 5
        };
    }
}
public class Jenny : PlayerClass
{
    public Jenny()
    {
        Name = "Jenny LeClerc";
        Color = "Purple";
        Age = 21;
        Gender = "Female";
        Height = "5'7\"";
        Weight = 142;
        Birthday = "March 4th";
        Hobbies = "Reading, Soccer (or Football for us Brits)";
        Description = "A quiet bookworm whose mother disappeared when she was younger. Jenny feels always alone.";
        Fears = "Being trapped in a crowd or lost in the open air.";
        SpeedLevel = 4;
        Speed = new int[] {
            0, 2, 3, 4, 4, 4, 5, 6, 8
        };
        MightLevel = 3;
        Might = new int[] {
            0, 3, 4, 4, 4, 4, 5, 6, 8
        };
        SanityLevel = 5;
        Sanity = new int[] {
            0, 1, 1, 2, 4, 4, 4, 5, 6
        };
        KnowledgeLevel = 3;
        Knowledge = new int[] {
            0, 2, 3, 3, 4, 4, 5, 6, 8
        };
    }
}
public class Heather : PlayerClass
{
    public Heather()
    {
        Name = "Heather Granville";
        Color = "Purple";
        Age = 18;
        Gender = "Female";
        Height = "5'2\"";
        Weight = 120;
        Birthday = "August 2nd";
        Hobbies = "Television, Shopping";
        Description = "Seen as perfect in both her eyes and the eyes of others, when things aren’t perfect she suffers from headaches. She keeps smiling anyway.";
        Fears = "Not being perfect.";
        SpeedLevel = 3;
        Speed = new int[] {
            0, 3, 3, 4, 5, 6, 6, 7, 8
        };
        MightLevel = 3;
        Might = new int[] {
            0, 3, 3, 3, 4, 5, 6, 7, 8
        };
        SanityLevel = 3;
        Sanity = new int[] {
            0, 3, 3, 3, 4, 5, 6, 6, 6
        };
        KnowledgeLevel = 5;
        Knowledge = new int[] {
            0, 2, 3, 3, 4, 5, 6, 7, 8
        };
    }
}
public class Zostra : PlayerClass
{
    public Zostra()
    {
        Name = "Madame Zostra";
        Color = "Blue";
        Age = 37;
        Gender = "Female";
        Height = "5'0\"";
        Weight = 150;
        Birthday = "December 10th";
        Hobbies = "Astrology, Cooking, Baseball";
        Description = "Also known as Belladina, Madame Zostra is a tarot card reader and tea-leaf reader with her own stay-at-home astrology business.";
        Fears = "Death, especially that of her self.";
        SpeedLevel = 3;
        Speed = new int[] {
            0, 2, 3, 3, 5, 5, 6, 6, 7
        };
        MightLevel = 4;
        Might = new int[] {
            0, 2, 3, 3, 4, 5, 5, 5, 6
        };
        SanityLevel = 3;
        Sanity = new int[] {
            0, 4, 4, 4, 5, 6, 7, 8, 8
        };
        KnowledgeLevel = 4;
        Knowledge = new int[] {
            0, 1, 3, 4, 4, 4, 5, 6, 6
        };
    }
}
public class Vivian : PlayerClass
{
    public Vivian()
    {
        Name = "Vivian Lopez";
        Color = "Blue";
        Age = 42;
        Gender = "Female";
        Height = "5'5\"";
        Weight = 142;
        Birthday = "January 11th";
        Hobbies = "Old Movies, Horses";
        Description = "A small bookshop owner who, when finances become difficult, has thoughts of arson.";
        Fears = "The same as one of her greatest loves – fire.";
        SpeedLevel = 4;
        Speed = new int[] {
            0, 3, 4, 4, 4, 4, 6, 7, 8
        };
        MightLevel = 3;
        Might = new int[] {
            0, 2, 2, 2, 4, 4, 5, 6, 6
        };
        SanityLevel = 3;
        Sanity = new int[] {
            0, 4, 4, 4, 5, 6, 7, 8, 8
        };
        KnowledgeLevel = 4;
        Knowledge = new int[] {
            0, 4, 5, 5, 5, 5, 6, 6, 7
        };
    }
}
public class Darrin : PlayerClass
{
    public Darrin()
    {
        Name = "Darrin \"Flash\" Williams";
        Color = "Red";
        Age = 20;
        Gender = "Male";
        Height = "5'11\"";
        Weight = 188;
        Birthday = "June 6th";
        Hobbies = "Track, Music, Shakespearean Literature";
        Description = "Flash is a paranoid runner, who can’t help but shake the feeling that something is chasing him.";
        Fears = "Getting caught by that which is chasing him.";
        SpeedLevel = 5;
        Speed = new int[] {
            0, 4, 4, 4, 5, 6, 7, 7, 8
        };
        MightLevel = 3;
        Might = new int[] {
            0, 2, 3, 3, 4, 5, 6, 6, 7
        };
        SanityLevel = 3;
        Sanity = new int[] {
            0, 1, 2, 3, 4, 5, 5, 5, 7
        };
        KnowledgeLevel = 3;
        Knowledge = new int[] {
            0, 2, 3, 3, 4, 5, 5, 5, 7
        };
    }
}
public class Ox : PlayerClass
{
    public Ox()
    {
        Name = "Ox Bellows";
        Color = "Red";
        Age = 20;
        Gender = "Male";
        Height = "6'4\"";
        Weight = 288;
        Birthday = "June 6th";
        Hobbies = "";
        Description = "A big kid who once had to lash out. Ox is now haunted by his past and what he did that one time.";
        Fears = "The dark.";
        SpeedLevel = 5;
        Speed = new int[] {
            0, 2, 2, 2, 3, 4, 5, 5, 6
        };
        MightLevel = 3;
        Might = new int[] {
            0, 4, 5, 5, 6, 6, 7, 8, 8
        };
        SanityLevel = 3;
        Sanity = new int[] {
            0, 2, 2, 3, 4, 5, 5, 6, 7
        };
        KnowledgeLevel = 3;
        Knowledge = new int[] {
            0, 2, 2, 3, 3, 5, 5, 6, 6
        };
    }
}
public class Brandon : PlayerClass
{
    public Brandon()
    {
        Name = "Brandon Jaspers";
        Color = "Green";
        Age = 12;
        Gender = "Male";
        Height = "5'1\"";
        Weight = 109;
        Birthday = "May 12th";
        Hobbies = "Computers, Camping, Hockey";
        Description = "A kid who never liked playing with traditional toys, Brandon could swear his old puppet was moving closer to him when he slept.";
        Fears = "Puppets, especially those of the clown variety.";
        SpeedLevel = 3;
        Speed = new int[] {
            0, 3, 4, 4, 4, 5, 6, 7, 8
        };
        MightLevel = 4;
        Might = new int[] {
            0, 2, 3, 3, 4, 5, 6, 6, 7
        };
        SanityLevel = 4;
        Sanity = new int[] {
            0, 3, 3, 3, 4, 5, 6, 7, 8
        };
        KnowledgeLevel = 3;
        Knowledge = new int[] {
            0, 1, 3, 3, 5, 5, 6, 6, 7
        };
    }
}
public class Peter : PlayerClass
{
    public Peter()
    {
        Name = "Peter Akimoto";
        Color = "Green";
        Age = 13;
        Gender = "Male";
        Height = "4'11\"";
        Weight = 98;
        Birthday = "September 3rd";
        Hobbies = "Bugs, Basketball";
        Description = "Seriously bullied by his family, Peter liked to hide under his house and look at bugs. He wants to be an entomologist.";
        Fears = "Getting caught somewhere he can’t get out.";
        SpeedLevel = 4;
        Speed = new int[] {
            0, 3, 3, 3, 4, 6, 6, 7, 6
        };
        MightLevel = 3;
        Might = new int[] {
            0, 2, 3, 3, 4, 5, 5, 6, 8
        };
        SanityLevel = 4;
        Sanity = new int[] {
            0, 3, 4, 4, 4, 5, 6, 6, 7
        };
        KnowledgeLevel = 3;
        Knowledge = new int[] {
            0, 3, 4, 4, 5, 6, 7, 7, 8
        };
    }
}
public class Rhinehardt : PlayerClass
{
    public Rhinehardt()
    {
        Name = "Father Rhinehardt";
        Color = "White";
        Age = 62;
        Gender = "Male";
        Height = "5'9\"";
        Weight = 185;
        Birthday = "April 29th";
        Hobbies = "Fencing, Gardening";
        Description = "A man who turned to religion to escape persecution, Father Rhinehardt is haunted by the mad whispers of the confessional booth.";
        Fears = "Going mad.";
        SpeedLevel = 3;
        Speed = new int[] {
            0, 2, 3, 3, 4, 5, 6, 7, 7
        };
        MightLevel = 3;
        Might = new int[] {
            0, 1, 2, 2, 4, 4, 5, 5, 7
        };
        SanityLevel = 5;
        Sanity = new int[] {
            0, 3, 4, 5, 5, 6, 7, 7, 8
        };
        KnowledgeLevel = 4;
        Knowledge = new int[] {
            0, 1, 3, 3, 4, 5, 6, 6, 8
        };
    }
}
public class Longfellow : PlayerClass
{
    public Longfellow()
    {
        Name = "Professor Longfellow";
        Color = "White";
        Age = 57;
        Gender = "Male";
        Height = "5'11\"";
        Weight = 153;
        Birthday = "July 27th";
        Hobbies = "Gaelic Music, Drama, Fine Wines";
        Description = "An aristocrat by birth, Professor Longfellow now lives with his mother, broke and wondering about her life insurance policy.";
        Fears = "Losing everything he has.";
        SpeedLevel = 4;
        Speed = new int[] {
            0, 2, 2, 4, 4, 5, 5, 6, 6
        };
        MightLevel = 3;
        Might = new int[] {
            0, 1, 2, 3, 4, 5, 5, 6, 6
        };
        SanityLevel = 3;
        Sanity = new int[] {
            0, 1, 3, 3, 4, 5, 5, 6, 7
        };
        KnowledgeLevel = 5;
        Knowledge = new int[] {
            0, 4, 5, 5, 5, 5, 6, 7, 8
        };
    }
}