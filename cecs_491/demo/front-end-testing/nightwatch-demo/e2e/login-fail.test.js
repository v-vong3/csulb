describe('Failed Login', function() {
    before(browser => browser.navigateTo('http://localhost:3000'));
  
    it('Initial page state', function (browser) {
        browser.expect.element("input[type='email']").to.have.value.that.equal("")
        browser.expect.element("input[type='email']").to.be.active
        browser.expect.element("input[type='password']").to.have.value.that.equal("")
        browser.assert.not.visible('.error-popup')
    })


    it('Error message appears', function(browser) {
      browser
        .click('button[class="login-btn"]')
        .expect.element('.error-popup').text.to.contain('login error')
    });

    it('Closing error message' ,function (browser) {
      browser
        .click('#clear')
        .assert.not.visible('.error-popup')
    });
  
    after(browser => browser.end());
  });