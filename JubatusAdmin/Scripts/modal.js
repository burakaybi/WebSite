    $(function () {
        // a tagimizde bulunan update idmiz click olduğunda
        $("body").on("click", "#update", function () {
            //data-target dan url mizi al
            var url = $(this).data("target");
            //bu urlimizi post et
            $.post(url, function (data) { })
                //eğer işlemimiz başarılı bir şekilde gerçekleşirse
                .done(function (data) {
                    //gelen datayı .modal-body mizin içerise html olarak ekle
                    $("#modelView .modal-body").html(data);
                    //sonra da modalimizi göster
                    $("#modelView").modal("show");
                    
                })
                //eğer işlem başarısız olursa
                .fail(function () {
                    //modalımızın bodysine Error! yaz
                    $("#modelView .modal-body").text("Error!!");
                    //sonra da modalimizi göster
                    $("#modelView").modal("show");
                })

        });
    })
