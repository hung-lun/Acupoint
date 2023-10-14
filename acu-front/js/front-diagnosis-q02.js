//登出
var logout1 = document.getElementById("logout");
logout1.addEventListener("click", logout);
    function logout() {
        if (confirm('確認要登出嗎？') == true) {
            window.location.href = "../acu-front/login.html";
            localStorage.clear();
        } else {
            return false;
        }
    }


    //把上一頁得到的分數加總
var getUrlString = location.href;  //取得網址
var url = new URL(getUrlString);  //將網址 (字串轉成URL)
var aa = url.searchParams.get('contact01');  //取得網址裡01=?
var bb = url.searchParams.get('contact02');  //取得網址裡02=?
var cc = url.searchParams.get('contact03');  //取得網址裡03=?
var dd = url.searchParams.get('contact04');  //取得網址裡04=?
var ee = url.searchParams.get('contact05');  //取得網址裡05=?
var ff = url.searchParams.get('contact06');  //取得網址裡06=?
var gg = url.searchParams.get('contact07');  //取得網址裡07=?
var hh = url.searchParams.get('contact08');  //取得網址裡08=?

var aa1 = parseInt(aa, 24);
var bb1 = parseInt(bb, 24);
var cc1 = parseInt(cc, 24);
var dd1 = parseInt(dd, 24);
var ee1 = parseInt(ee, 24);
var ff1 = parseInt(ff, 24);
var gg1 = parseInt(gg, 24);
var hh1 = parseInt(hh, 24);

var total = aa1+bb1+cc1+dd1+ee1+ff1+gg1+hh1;
// alert(total);