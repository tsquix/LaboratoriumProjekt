// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
'use strict'

const reg = document.querySelector('#register');
const log = document.querySelector('#login');
const manage = document.querySelector('#manage');
const btn = document.querySelector('.lightmodebtn');
const body = document.querySelector('.bodybody');
const nav = document.querySelector('.navnav');
const logout = document.querySelector('#logout');
function setModeFromLocalStorage() {
    const isLightMode = localStorage.getItem('isLightMode') === 'true';

    if (isLightMode) {
        //tryb jasny
        body.classList.remove('text-light', 'bg-dark');
        nav.classList.remove('navbar-dark', 'text-white');
        nav.classList.add('navbar-light', 'text-black');
        logout.classList.remove('text-light');
        if (reg) reg.classList.remove('text-light');
        if (log) log.classList.remove('text-light');
        if (manage) manage.classList.remove('text-light');

        const elements = document.querySelectorAll('.text-white');
        elements.forEach(function (element) {
            element.classList.remove('text-white');
        });
    }
}
setModeFromLocalStorage();

btn.addEventListener('click', function () {
    const isLightMode = localStorage.getItem('isLightMode') === 'true';

    // zmiana trybu
    if (isLightMode) {
        body.classList.add('text-light', 'bg-dark');
        nav.classList.remove('navbar-light', 'text-black');
        nav.classList.add('navbar-dark', 'text-white');
        logout.classList.add('text-light');
        const elements = document.querySelectorAll('.tw');
        elements.forEach(function (element) {
            element.classList.add('text-white');
        });
        if (log) log.classList.add('text-light');
        if (manage) manage.classList.add('text-light');
        if (reg) reg.classList.add('text-light');
    } else {        // jezeli tryb był ciemny, przełącz na tryb jasny
        body.classList.remove('text-light', 'bg-dark');
        nav.classList.remove('navbar-dark', 'text-white');
        nav.classList.add('navbar-light', 'text-black');
        logout.classList.remove('text-light');
        if (reg) reg.classList.remove('text-light');
        if (log) log.classList.remove('text-light');
        if (manage) manage.classList.remove('text-light');

        const elements = document.querySelectorAll('.text-white');
        elements.forEach(function (element) {
            element.classList.remove('text-white');
        });
    }
    localStorage.setItem('isLightMode', !isLightMode);
});
