const $navbar = $('navbar');
$navbar.find('.options .btn-option').on('click', function (e) {
    const $this = $(this);
    $this.parent().parent().find('button.selected').find('img.icon').first().removeClass('d-none');
    $this.parent().parent().find('button.selected').find('img.icon').last().addClass('d-none');
    $this.parent().parent().find('button.selected').removeClass('selected').find('img.icon')
    $this.addClass('selected');
    $this.addClass('selected').find('img.icon').first().addClass('d-none');
    $this.addClass('selected').find('img.icon').last().removeClass('d-none');
})