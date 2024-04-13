using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Without_At_And_Dot()
    {
        //Arrange
        String firstName = "John";
        String lastName = "Kowalski";
        DateTime birthDate = new DateTime(1980, 1, 1);
        String email = "kowalski";
        int clientID = 1;
        var userService = new UserService();
        
        //Act
        bool result = userService.AddUser(firstName, lastName, email, birthDate, clientID);
        
        //Assert
        Assert.Equal(false,result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_First_Name_Is_Null()
    {
        //Arrange
        String firstName = null;
        String lastName = "Kowalski";
        DateTime birthDate = new DateTime(1980, 1, 1);
        String email = "kowalski@wp.pl";
        int clientID = 1;
        var userService = new UserService();
        
        //Act
        bool result = userService.AddUser(firstName, lastName, email, birthDate, clientID);
        
        //Assert
        Assert.Equal(false,result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Last_Name_Is_Null()
    {
        //Arrange
        String firstName = "John";
        String lastName = null;
        DateTime birthDate = new DateTime(1980, 1, 1);
        String email = "kowalski@wp.pl";
        int clientID = 1;
        var userService = new UserService();
        
        //Act
        bool result = userService.AddUser(firstName, lastName, email, birthDate, clientID);
        
        //Assert
        Assert.Equal(false,result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Age_Is_Lesser_Than_21()
    {
        //Arrange
        String firstName = "John";
        String lastName = "Kowalski";
        DateTime birthDate = new DateTime(2003, 9, 1);
        String email = "kowalski@wp.pl";
        int clientID = 1;
        var userService = new UserService();
        
        //Act
        bool result = userService.AddUser(firstName, lastName, email, birthDate, clientID);
        
        //Assert
        Assert.Equal(false,result);
    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_Very_Important_Client()
    {
        //Arrange
        String firstName = "John";
        String lastName = "Malewski";
        DateTime birthDate = new DateTime(1980, 1, 1);
        String email = "malewski@gmail.pl";
        int clientID = 2;
        var userService = new UserService();
        
        //Act
        bool result = userService.AddUser(firstName, lastName, email, birthDate, clientID);
        
        //Assert
        Assert.Equal(true,result);
    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_Important_Client()
    {
        //Arrange
        String firstName = "John";
        String lastName = "Smith";
        DateTime birthDate = new DateTime(1980, 1, 1);
        String email = "smith@gmail.pl";
        int clientID = 3;
        var userService = new UserService();
        
        //Act
        bool result = userService.AddUser(firstName, lastName, email, birthDate, clientID);
        
        //Assert
        Assert.Equal(true,result);
    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_Normal_Client()
    {
        //Arrange
        String firstName = "John";
        String lastName = "Kwiatkowski";
        DateTime birthDate = new DateTime(1980, 1, 1);
        String email = "kwiatkowski@wp.pl";
        int clientID = 5;
        var userService = new UserService();
        
        //Act
        bool result = userService.AddUser(firstName, lastName, email, birthDate, clientID);
        
        //Assert
        Assert.Equal(true,result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Credit_Limit_Below_500()
    {
        //Arrange
        String firstName = "John";
        String lastName = "Polak";
        DateTime birthDate = new DateTime(1980, 1, 1);
        String email = "polak@wp.pl";
        int clientID = 7;
        var userService = new UserService();
        
        //Act
        bool result = userService.AddUser(firstName, lastName, email, birthDate, clientID);
        
        //Assert
        Assert.Equal(false,result);
    }}