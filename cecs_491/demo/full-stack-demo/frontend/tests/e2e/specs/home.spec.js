// https://docs.cypress.io/api/introduction/api.html

describe('Home page test', () => {
    it('Visits the login page url', () => {
      cy.visit('/')
      cy.contains('div', 'This is the home page')
    })

  })