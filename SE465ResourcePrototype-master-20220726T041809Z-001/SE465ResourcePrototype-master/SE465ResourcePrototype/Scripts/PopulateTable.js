function pageLoad() {
    $.get('AppData/resources.txt', function (data) {
        var lines = data.split("\n");

        $.each(lines, function (n, elem) {
            var segments = elem.split("|");
            var row = "<tr>";
            $('<tr>').insertBefore('#footer');
            $.each(segments, function (n, elem2) {
                $('<td>' + elem2 + '</td>').insertBefore('#footer');
            });
            $('</tr>').insertBefore('#footer');

        });
    });
};