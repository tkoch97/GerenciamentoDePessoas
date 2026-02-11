jQuery.noConflict();
(function ($) {
    $(document).ready(function () {
        $('.tabela-pessoas').DataTable(
            {
                language: {
                    url: '//cdn.datatables.net/plug-ins/2.3.7/i18n/pt-BR.json',
                }
            }
        );
    });
})(jQuery);

$(document).ready(function () {
    $('#buscarTotalPessoas').click(function () {
        $('#resultadoTotalPessoas').text('');

        $.ajax({
            method: "GET",
            url: "/Pessoa/Total",
            dataType: "text",    //tipo de resposta esperada
            success: function (data) {
                $('#resultadoTotalPessoas').text(`Total de pessoas registradas: ${data}`);
            },
            error: function (xhr, status, error) {
                console.error(`Erro: ${status} - ${error}`);
                $('#resultadoTotalPessoas').text('Erro ao buscar o total de pessoas.');
            }
        })
    })
});
