$(function () {
    // a tagimizde bulunan update idmiz click olduğunda
    $("body").on("click", "#delete", function () {
        //data-target dan url mizi al
        var url = $(this).data("target");
        //bu urlimizi post et
        $.post(url, function (data) { })
            //eğer işlemimiz başarılı bir şekilde gerçekleşirse
            .done(function (data) {
                //gelen datayı .modal-body mizin içerise html olarak ekle
                $("#deleteView .modal-body").html(data);
                //sonra da modalimizi göster
                $("#deleteView").modal("show");

            })
            //eğer işlem başarısız olursa
            .fail(function () {
                //modalımızın bodysine Error! yaz
                $("#deleteView .modal-body").text("Error!!");
                //sonra da modalimizi göster
                $("#deleteView").modal("show");
            })

    });
})
