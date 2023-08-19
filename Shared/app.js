//    /*fa-spin*/
// variables linked with the html file
const body = document.querySelector('body');

// navbar variables
const navButton = document.querySelector('.navButton');
const navbar = document.querySelector('nav');
const navbarText = document.querySelectorAll('nav div span');

// navbar shrinck button
navbar.style.height = (this.window.innerHeight - (this.window.innerHeight / 31)) + 'px';
console.log(this.window.innerHeight);
navbar.style.height = window.innerHeight;
let shrinked = false;
body.style.paddingLeft = 255 + 'px';
function navbarButton(){
    if (!shrinked) {
        navbar.style.width = '65px';
        shrinked = true;
        body.style.paddingLeft = '70px';
        for (let i = 0; i < navbarText.length; i++) {
            navbarText[i].style.display = 'none';
        }
    } else {
        navbar.style.width = '250px';
        shrinked = false;
        body.style.paddingLeft = '255px';
        for (let i = 0; i < navbarText.length; i++) {
            navbarText[i].style.display = 'inline';
        }
    }
}
window.addEventListener("resize", function () {
    navbar.style.height = (this.window.innerHeight - (this.window.innerHeight / 31)) + 'px';
})