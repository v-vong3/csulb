const RegService = require('./RegistrationService');

test('Create account using valid inputs (Should PASS)', () => {
    // Arrange
    let username = 'alice@google.com'
    let password = 'password'

    // Act
    let actual = RegService.createUserAccount(username, password);

    // Assert
    expect(actual).toBe(true); // assert.isTrue()
  });


  test('Create account using invalid password (Should FAIL)', () => {
    // Arrange
    let username = 'alice@google.com'
    let password = 'pass'

    // Act
    let actual = RegService.createUserAccount(username, password);

    // Assert
    expect(actual).toBe(false); 
  });

  test('Create account using invalid username (Should FAIL)', () => {
    // Arrange
    let username = 'alice'
    let password = 'password'

    // Act
    let actual = RegService.createUserAccount(username, password);

    // Assert
    expect(actual).toBe(false); 
  });