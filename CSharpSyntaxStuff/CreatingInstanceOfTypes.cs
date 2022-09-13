using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSyntaxStuff;

public class CreatingInstanceOfTypes
{
    [Fact]
    public void DeterminingType()
    {
        Int32 x = 12;
        int y = 12;

        string myName = "Jimit";
        String yourName = "Ringo";
    }

    [Fact]
    public void ImplicitVariableDeclaration()
    {
        var x = 12;
        var y = "Monkey";

        var bob = new Employee();
        var myPay = new PayCheck();
        var manager = new Manager();
        manager.SaveThis(bob);
        manager.SaveThis(myPay);
        manager.SaveThis("Tacos");
        manager.SaveThis(42);
    }

    [Fact]
    public void OldSchoolCollections()
    {
        var favoriteNumbers = new ArrayList();
        favoriteNumbers.Add(9);
        favoriteNumbers.Add(42);
        favoriteNumbers.Add(20);
        Assert.Equal(9, favoriteNumbers[0]);

        favoriteNumbers.Add("Pizza");
        // favoriteNumbers[0] = "Three";
        var sumOfFirstTwo = ((int)favoriteNumbers[0]) + ((int)favoriteNumbers[1]);
        Assert.Equal(51, sumOfFirstTwo);
    }

    [Fact]
    public void NewSchoolCollections()
    {
        // Parametric Polymorphism
        var favoriteNumbers = new List<int>();
        favoriteNumbers.Add(9);
        favoriteNumbers.Add(42);
        favoriteNumbers.Add(20);
        var sumOfFirstTwo = favoriteNumbers[0] + favoriteNumbers[1];
        Assert.Equal(51, sumOfFirstTwo);
    }
}

public class Employee { }

public class PayCheck { }

public class Manager
{
    public void SaveThis(Object o)
    {

    }
}