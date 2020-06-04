$(function () {

    $.post("lib/listarSeries.aspx", null, function (retorno) {

        $('.conteudo').html(retorno);
    });


});