describe('Login Success', function() {
    before(browser => browser.navigateTo('http://localhost:3000'));
  

    it('Login with test user', function(browser) {

      let duration;

      browser
        .setValue('input[type=email]', 'test')
        .setValue('input[type=password]', 'test')
        .pause()
        .click('button[class="login-btn"]')

        .perform(function () {
            duration = Date.now();
        })
        .waitForElementVisible('#banner', function() {
            duration = (Date.now() - duration) / 1000;
        })
        .perform(function () {
            if(duration > 5) {
                throw new Error('NFR failed')
            }
        })
        .assert.urlContains("/home.html")
    });
  
    after(browser => browser.end());
  });