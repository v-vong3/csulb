
// Flow: Visit->Query->Action->Should

describe('Login page test', () => {

    it('Login failed', () => {


    })

    it('Login with a valid user', () => {
      
      // Visit
      cy.visit('/views/login/login.html')

      // Query
      cy.get('input[type="username"]').type('john');
      cy.get('input[type="password"]').type('smith');
  
      // Action
      cy.get('button').click();
      
      // Should
      cy.on('window:alert', (s) => {
        expect(s).to.equal('Login Success');
      })

      cy.get("#success").then(e => {

        if(e.is(':visible')) {
          
          expect(e[0].innerText).to.equal('Login success')
        }
      })


      
    })
  })