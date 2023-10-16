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


var getUrlString = location.href;  //取得網址
// var url = new URL(getUrlString);  //將網址 (字串轉成URL)

var count1 = (getUrlString.match(/011/g) || []).length;  //取得011有幾個 - 肝腎陰虛型
console.log(count1);

var count2 = (getUrlString.match(/022/g) || []).length;  //取得022有幾個 - 肺陰不足型
console.log(count2);

var count3 = (getUrlString.match(/033/g) || []).length;  //取得033有幾個 - 脾胃溼熱型
console.log(count3);

var count4 = (getUrlString.match(/044/g) || []).length;  //取得044有幾個 - 脾肺伏熱型
console.log(count4);

var count5 = (getUrlString.match(/055/g) || []).length;  //取得055有幾個 - 肝氣鬱結型
console.log(count5);

var count6 = (getUrlString.match(/066/g) || []).length;  //取得066有幾個 - 脾肺虛寒型
console.log(count6);

// var aa = url.searchParams.get('01');  //取得網址裡01=?
// var bb = url.searchParams.get('02');  //取得網址裡02=?
// var cc = url.searchParams.get('03');  //取得網址裡03=?
// var dd = url.searchParams.get('04');  //取得網址裡04=?
// var ee = url.searchParams.get('05');  //取得網址裡05=?
// var ff = url.searchParams.get('06');  //取得網址裡06=?

var medicine_button = document.getElementById("medicine_button");
var result04 = document.getElementById("result04");
var result00 = document.getElementById("result00");
if((count1 > count2) & (count1 > count3) & (count1 > count4) & (count1 > count5) & (count1 > count6)){
    medicine_button.innerHTML="<label><input id='m0101' class='mouse button' type='radio' name='MM' value='杞菊地黃丸' checked/><span class='medicine-button mouse'>杞菊地黃丸</span></label><label><input id='m0102' class='mouse button' type='radio' name='MM' value='滋腎明目湯' /><span class='medicine-button mouse'>滋腎明目湯</span></label>"
    result04.innerHTML="”肝腎陰虛型”"

    var m0101 = document.getElementById("m0101");  //杞菊地黃丸
    m0101.addEventListener("click", m01011);
    function m01011(){
        document.getElementById("medicine").src = "../acu-front/medicine/01-01.html";
    }

    var m0102 = document.getElementById("m0102");  //滋腎明目湯
    m0102.addEventListener("click", m01022);
    function m01022(){
        document.getElementById("medicine").src = "../acu-front/medicine/01-02.html";
    }

    if(document.getElementById("m0101").checked) {
        document.getElementById("medicine").src = "../acu-front/medicine/01-01.html";
    }
}else if((count2 > count1) & (count2 > count3) & (count2 > count4) & (count2 > count5) & (count2 > count6)){
    medicine_button.innerHTML="<label><input id='m0201' class='mouse button' type='radio' name='MM' value='養陰清肺湯' checked/><span class='medicine-button mouse'>養陰清肺湯</span></label><label><input id='m0202' class='mouse button' type='radio' name='MM' value='百合固金湯' /><span class='medicine-button mouse'>百合固金湯</span></label>"
    result04.innerHTML="”肺陰不足型”"

    var m0201 = document.getElementById("m0201");  //養陰清肺湯
    m0201.addEventListener("click", m02011);
    function m02011(){
        document.getElementById("medicine").src = "../acu-front/medicine/02-01.html";
    }

    var m0202 = document.getElementById("m0202");  //百合固金湯
    m0202.addEventListener("click", m02022);
    function m02022(){
        document.getElementById("medicine").src = "../acu-front/medicine/02-02.html";
    }

    if(document.getElementById("m0201").checked){
        document.getElementById("medicine").src = "../acu-front/medicine/02-01.html";
    }
}else if((count3 > count1) & (count3 > count2) & (count3 > count4) & (count3 > count5) & (count3 > count6)){
    medicine_button.innerHTML="<label><input id='m0301' class='mouse button' type='radio' name='MM' value='三仁湯' checked/><span class='medicine-button mouse'>三仁湯</span></label>"
    result04.innerHTML="”脾胃溼熱型”"

    var m0301 = document.getElementById("m0301");  //三仁湯
    m0301.addEventListener("click", m03011);
    function m03011(){
        document.getElementById("medicine").src = "../acu-front/medicine/03-01.html";
    }

    if(document.getElementById("m0301").checked){
        document.getElementById("medicine").src = "../acu-front/medicine/03-01.html";
    }
}else if((count4 > count1) & (count4 > count2) & (count4 > count3) & (count4 > count5) & (count4 > count6)){
    medicine_button.innerHTML="<label><input id='m0401' class='mouse button' type='radio' name='MM' value='桑白皮湯' checked/><span class='medicine-button mouse'>桑白皮湯</span></label><label><input id='m0402' class='mouse button' type='radio' name='MM' value='銀翹散' /><span class='medicine-button mouse'>銀翹散</span></label>"
    result04.innerHTML="”脾肺伏熱型”"

    var m0401 = document.getElementById("m0401");  //桑白皮湯
    m0401.addEventListener("click", m04011);
    function m04011(){
        document.getElementById("medicine").src = "../acu-front/medicine/04-01.html";
    }

    var m0402 = document.getElementById("m0402");  //銀翹散
    m0402.addEventListener("click", m04022);
    function m04022(){
        document.getElementById("medicine").src = "../acu-front/medicine/04-02.html";
    }

    if(document.getElementById("m0401").checked){
        document.getElementById("medicine").src = "../acu-front/medicine/04-01.html";
    }
}else if((count5 > count1) & (count5 > count2) & (count5 > count3) & (count5 > count4) & (count5 > count6)){
    medicine_button.innerHTML="<label><input id='m0501' class='mouse button' type='radio' name='MM' value='加味逍遙散' checked/><span class='medicine-button mouse'>加味逍遙散</span></label><label><input id='m0502' class='mouse button' type='radio' name='MM' value='柴胡疏肝散' /><span class='medicine-button mouse'>柴胡疏肝散</span></label>"
    result04.innerHTML="”肝氣鬱結型”"

    var m0501 = document.getElementById("m0501");  //加味逍遙散
    m0501.addEventListener("click", m05011);
    function m05011(){
        document.getElementById("medicine").src = "../acu-front/medicine/05-01.html";
    }

    var m0502 = document.getElementById("m0502");  //柴胡疏肝散
    m0502.addEventListener("click", m05022);
    function m05022(){
        document.getElementById("medicine").src = "../acu-front/medicine/05-02.html";
    }

    if(document.getElementById("m0501").checked){
        document.getElementById("medicine").src = "../acu-front/medicine/05-01.html";
    }
}else if((count6 > count1) & (count6 > count2) & (count6 > count3) & (count6 > count4) & (count6 > count5)){
    medicine_button.innerHTML="<label><input id='m0601' class='mouse button' type='radio' name='MM' value='香砂六君子湯' checked/><span class='medicine-button mouse'>香砂六君子湯</span></label>"
    result04.innerHTML="”脾肺虛寒型”"

    var m0601 = document.getElementById("m0601");  //香砂六君子湯
    m0601.addEventListener("click", m06011);
    function m06011(){
        document.getElementById("medicine").src = "../acu-front/medicine/06-01.html";
    }

    if(document.getElementById("m0601").checked){
        document.getElementById("medicine").src = "../acu-front/medicine/06-01.html";
    }
}else if((count1 == 0) & (count2 == 0) & (count3 == 0) & (count4 == 0) & (count5 == 0) & (count6 == 0)){
    medicine_button.innerHTML="<label><input id='m0001' class='mouse button' type='radio' name='MM' value='枸杞菊花茶' checked/><span class='medicine-button mouse'>枸杞菊花茶</span></label><label><input id='m0002' class='mouse button' type='radio' name='MM' value='枸杞夏枯草' /><span class='medicine-button mouse'>枸杞夏枯草</span></label><label><input id='m0003' class='mouse button' type='radio' name='MM' value='黃耆枸杞紅棗茶' /><span class='medicine-button mouse'>黃耆枸杞紅棗茶</span></label>"
    result04.innerHTML="”無症狀”"
    result00.innerHTML="<div class='result001'>”無症狀，日常可以飲用以下中藥食療。”</div>"
}else{
    medicine_button.innerHTML="<label><input id='m0001' class='mouse button' type='radio' name='MM' value='枸杞菊花茶' checked/><span class='medicine-button mouse'>枸杞菊花茶</span></label><label><input id='m0002' class='mouse button' type='radio' name='MM' value='枸杞夏枯草' /><span class='medicine-button mouse'>枸杞夏枯草</span></label><label><input id='m0003' class='mouse button' type='radio' name='MM' value='黃耆枸杞紅棗茶' /><span class='medicine-button mouse'>黃耆枸杞紅棗茶</span></label>"
    result04.innerHTML="”與多症狀類型相符”"
    result00.innerHTML="<div class='result001'>”與多症狀類型相符，日常可以多飲用以下中藥食療，進階中醫食療請向中醫師諮詢。”</div>"
}
