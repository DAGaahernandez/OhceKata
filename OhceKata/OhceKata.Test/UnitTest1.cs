using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace OhceKata.Test;

public class OhceShould {
    [SetUp]
    public void Setup() {
        
    }

    [Test]
    public void give_greetings_to_user() {
        //Given;
        
        //When
        var console = new MockConsole();
        new Ohce(console).Start();
        
        //Then
        Assert.AreEqual(console.LastText, "¡Buenos días Pedro!");
    }
}

public interface IConsole {
    void Write(string message);
}

public class MockConsole : IConsole {
    public string LastText { get; private set; }

    public void Write(string message) {
        LastText = message;
    }
}

public class Ohce {
    private readonly IConsole _console;

    public Ohce(IConsole console) {
        _console = console;
    }

    public void Start() {
        _console.Write("¡Buenos días Pedro!");
    }
}