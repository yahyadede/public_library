const SNHbutton = document.querySelector('.showNhide');
const passwordInput = document.querySelector('.password');




let hidden = true;
function showNhide() {
    if (hidden) {
        hidden = false;
        SNHbutton.innerHTML = '<i class="fa-solid fa-eye"></i>';
        passwordInput.type = 'text';
    } else {
        hidden = true;
        SNHbutton.innerHTML = '<i class="fa-solid fa-eye-slash"></i>';
        passwordInput.type = 'password';
    }
}