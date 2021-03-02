

function parseCookie(cookie) {
    return cookie.split(';').find((x) => x.startsWith("username=")).split("=")[1];
}


test('parse cookie with valid username', () => {
    // Arrange
    var validCookie = "username=john";

    // Act
    var actual = parseCookie(validCookie);

    
    // Assert
    expect(actual).toBe("john");

    // toEqual
    // not.toBe
    // toBeNull
    // toBeUndefined
    // toBeDefined
    // toBeTruthy
    // toBeFalsy
    // toBeGreaterThan
    // toBeLessThan
    // toBeGreaterThanOrEqual
    // toBeLessThanOrEqual
    // toMatch
    // not.toMatch
    // toContain
    // toThrow
})