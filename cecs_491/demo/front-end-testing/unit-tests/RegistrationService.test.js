const RegService = require('./RegistrationService');

test('create account with valid inputs', () => {
    // Arrange
    let username = 'alice@google.com'
    let password = 'password'

    // Act
    let actual = RegService.createUserAccount(username, password);

    // Assert
    expect(actual).toBe(true); 
  });


  test('create account with invalid password', () => {
    // Arrange
    let username = 'alice@google.com'
    let password = 'pass'

    // Act
    let actual = RegService.createUserAccount(username, password);

    // Assert
    expect(actual).toBe(false); 
  });

  test('create account with invalid username', () => {
    // Arrange
    let username = 'alice'
    let password = 'password'

    // Act
    let actual = RegService.createUserAccount(username, password);

    // Assert
    expect(actual).toBe(false); 
  });