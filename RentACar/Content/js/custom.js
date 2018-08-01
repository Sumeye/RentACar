$(document).ready(function () {
    //Rezervasyon Controllerdeki Listele sayfasında bulunan silme butonlarına uygulanan Jquery Kodu başlangıç
    $("#ReservationTable").on("click", ".DeleteReservation", function (result) {
        var id = $(this).attr("data-id");
        var parent = $(this).parent("td").parent("tr");
        var confirmDelete = confirm("Bu kaydı silmek istediğinize emin misiniz?");
        if (confirmDelete) {
            $.ajax({
                type: "POST",
                url: "/Rezervasyon/DeleteReservation",
                data: { "id": id },
                success: function (cevap) {
                    $("#rezervationsilmeuyarisi").fadeIn(2000).text(cevap).delay(100).fadeOut(1000);
                    parent.fadeOut(1000, function () {
                        parent.remove();
                    });
                    //$("#RezervationList").load('/Rezervasyon/List');
                }
            });
        }
    });
    //Rezervasyon Controllerdeki Listele sayfasında bulunan silme butonlarına uygulanan Jquery Kodu bitiş

    //Rezervasyon Arama Sayfası
        $("#btn_ReservationSearch").click(function () {
            var ReservationStartDate = $("#RezerveTarih").val();
            var ReservationEndDate = $("#RezerveBitisTarihi").val();
            console.log(ReservationStartDate);
            console.log(ReservationEndDate);
            $.ajax({
                type: "POST",
                url: "/Rezervasyon/ReservationSearch",
                data: { "StartDate": ReservationStartDate, "EndDate": ReservationEndDate },
                success: function (result)
                {
                    $("#ReservationTable tbody").remove();
                    var content = "";
                    $(result).each(function (index, item) {

                        var string_RezerveTarih = item.RezerveTarih.replace('/', '').replace('/', '');
                        var RezerveTarih = eval("new " + string_RezerveTarih).toLocaleDateString();


                        var string_RezerveBitisTarihi = item.RezerveBitisTarihi.replace('/', '').replace('/', '');
                        var RezerveBitisTarihi = eval("new " + string_RezerveBitisTarihi).toLocaleDateString();

                        content += "<tbody>";
                        content += "<tr>";
                        content += "<td>" + parseInt(index + 1) + "</td>";
                            content += "<td>" + item.MusteriID + "</td>";
                            content += "<td>" + item.AracID + "</td>";
                            content += "<td>" + RezerveTarih + "</td>";
                            content += "<td>" + item.RezerveSure + "</td>";
                            content += "<td>" + RezerveBitisTarihi + "</td>";
                            content += "<td>" + item.RezerveUcret + "</td>";
                            content += "<td>" + item.RezerveUcretBirimi + "</td>";
                            content += "<td>";
                                content += '<a class="fa fa-pencil btn btn-success" href="/Rezervasyon/Edit/'+item.RezervasyonId+'"></a>';
                                content += '<button class="DeleteReservation btn btn-danger fa fa-trash" data-id="'+item.RezervasyonId + '"></button>';
                            content += "</td>";
                        content += "<tr>";
                        content += "</tbody>";
                    });
                    $("#ReservationTable").append(content);
             }
        })
    })
    //Rezervasyon Arama Bitiş
});






