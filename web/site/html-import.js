document.querySelectorAll('[data-import-src]')
    .forEach(elem => fetch(elem.getAttribute("data-import-src"))
        .then(stream => stream.text())
        .then(text => {
            elem.insertAdjacentHTML('beforebegin', text);
            elem.remove();
        }));
document.querySelector('script[src="html-import.js"]').remove();
