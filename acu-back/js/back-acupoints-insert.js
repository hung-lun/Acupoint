var logout1 = document.getElementById("logout");
logout1.addEventListener("click", logout);
    function logout() {
        if (confirm('確認要登出嗎？') == true) {
            window.location.href = "../acu-front/login.html";
            localStorage.clear();
        } else {

        }
    }
    
    var button1 = document.getElementById("insert1");
    var button2 = document.getElementById("insert2");
    var button3 = document.getElementById("insert3");
    var button4 = document.getElementById("insert4");
    button1.addEventListener("click", showPopupp1);
    button2.addEventListener("click", showPopupp2);
    button3.addEventListener("click", showPopupp3);
    button4.addEventListener("click", showPopupp4);
    var change = document.getElementById("change");
    function showPopupp1() {
        // var change = document.getElementById("change");
        change.innerHTML="<div class='acupoint_info'><i class='fa-solid fa-location-crosshairs'>　穴道位置：</div><textarea name='editorDemo' id='editorDemo' style='white-space:pre-wrap;' class='textarea'></textarea>"
        var editor = CKEDITOR.replace("editorDemo");
        document.getElementById("popupp").style.display = "block"; // 顯示浮動視窗
    }
    function showPopupp2() {
        // var change = document.getElementById("change");
        change.innerHTML="<div class='acupoint_info'><i class='fa-solid fa-compress'></i>　按壓方式：</div><textarea name='editorDemo' id='editorDemo' style='white-space:pre-wrap;' class='textarea'></textarea>"
        var editor = CKEDITOR.replace("editorDemo");
        document.getElementById("popupp").style.display = "block"; // 顯示浮動視窗
    }
    function showPopupp3() {
        // var change = document.getElementById("change");
        change.innerHTML="<div class='acupoint_info'><i class='fa-solid fa-signature'></i>　穴名介紹：</div><textarea name='editorDemo' id='editorDemo' style='white-space:pre-wrap;' class='textarea'></textarea>"
        var editor = CKEDITOR.replace("editorDemo");
        document.getElementById("popupp").style.display = "block"; // 顯示浮動視窗
    }
    function showPopupp4() {
        // var change = document.getElementById("change");
        change.innerHTML="<div class='acupoint_info'><i class='fa-solid fa-book-journal-whills'></i>　穴道名稱：</div><textarea name='editorDemo' id='editorDemo' style='white-space:pre-wrap;' class='textarea'></textarea>"
        var editor = CKEDITOR.replace("editorDemo");
        document.getElementById("popupp").style.display = "block"; // 顯示浮動視窗
    }

    function insertcancel() {
        // 關閉浮動視窗
        document.getElementById("popupp").style.display = "none";
      }
