
// 1. Use of 'const' to declare function to protect against reassignment
//      Note that this will cause the Reset button to fail on this page
// 2. Code has been obfuscated to reduce human readability of business logic
//      Note how much more difficult to tell what 'add' aka 'a' is supposed to do
// 3. Code has been minified (white spaces removed & variables renamed) 
// to reduce file size and reduce human readability of code
//      Note that the minification process does not rename JavaScript variables in
//      HTML files so that will require another step to reconcile prior to deployment
// FYI, this entire comment block would be removed during the minification process

const a=function(l,r,s,t){return function(s){return l;}()+function(t){return r;}()}