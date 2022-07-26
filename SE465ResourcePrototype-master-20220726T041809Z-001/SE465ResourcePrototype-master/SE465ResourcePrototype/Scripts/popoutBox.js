$(window).load(function () {
    $(".trigger_popup_fricc").click(function () {
        $('.hover_bkgr_fricc').show();
    });
    $('.hover_bkgr_fricc').click(function () {
        location.reload(true);
        $('.hover_bkgr_fricc').hide();
    });
    $('.popupCloseButton').click(function () {
        location.reload(true);
        $('.hover_bkgr_fricc').hide();
    });
});