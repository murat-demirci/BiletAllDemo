const $navbar = $('navbar');
let countAnim = 0;

const sleeper = (ms) =>
    new Promise((resolve) => {
        setTimeout(() => {
            resolve();
        }, ms);
    });

listCities();

$navbar.find('.options .btn-option').on('click', function (e) {
    const $this = $(this);
    $this.parent().parent().find('button.selected').find('img.icon').first().removeClass('d-none');
    $this.parent().parent().find('button.selected').find('img.icon').last().addClass('d-none');
    $this.parent().parent().find('button.selected').removeClass('selected').find('img.icon')
    $this.addClass('selected');
    $this.addClass('selected').find('img.icon').first().addClass('d-none');
    $this.addClass('selected').find('img.icon').last().removeClass('d-none');
})

async function listCities() {
    const response = await fetch('/Home/ListKaraNokta');
    const json = await response.json();
    if (!json) return;
    
    $.each(json, function () {
        $navbar.find('.search-panel input#fromDropdown').next().prepend(`<a class="dropdown-item" href="#" onclick="selectItem(event,'input#fromDropdown')" data-bs-id="${this.id}">${this.ad}</a>`);
        $navbar.find('.search-panel input#toDropdown').next().prepend(`<a class="dropdown-item" href="#" onclick="selectItem(event,'input#toDropdown')"  data-bs-id="${this.id}">${this.ad}</a>`);
    })

    $navbar.find('.search-panel input#fromDropdown,.search-panel input#toDropdown').on('focus', function () {
        $(this).next().addClass('d-block');
    });

    $navbar.find('.search-panel input#fromDropdown,.search-panel input#toDropdown').on('focusout', function () {
        $(this).next().removeClass('d-block');
    });
}

function selectItem(e, target) {
    console.log(target)
    console.log(e)
    $navbar.find('.search-panel ' + e.currentTarget.getAttribute('data-bs-target')).val(e.currentTarget.innerText);
}