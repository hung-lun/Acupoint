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



const url = "https://localhost:7105/api/Eye_question/GetQuestion";
  let data = [];
  fetch(url) //判斷api有沒有資料
    .then((response) => {
      if (response.ok) {
        //如果api有資料就執行以下程式碼顯示資料

        // step 1 - 取得資料
        (function getData() {
          axios.get(url).then(function (response) {
            // 檢查
            console.log(response.data);
            // 將取得資料帶入空陣列data中
            data = response.data;
            const eightdata = data.slice(0,8);
            const fourdata = data.slice(8,12);
            const threedata = data.slice(12,15);
            console.log(eightdata.length);
            data = eightdata;
            data1 = fourdata;
            data2 = threedata;
            // title(data);
            title1(data1);
            title2(data2);
          });
        })();

        function title1(arr) {
          // 抓取欄位
          const p_title = document.querySelector("#question_content1");
          let str = "";
          // 將資料存入
          let aa = 0;
          arr.forEach(function (data) {
            aaa=`
            <tr>
                    <td class="Q-title">　</td>
                    <td class="Q-option">隨時</td>
                    <td class="Q-option">大部分時間</td>
                    <td class="Q-option">約一半時間</td>
                    <td class="Q-option">偶爾</td>
                    <td class="Q-option">無</td>
                </tr>
            `;
            aa++;
            str += 
            `<tr>
                <td class="Q-title">${data.eye_question_content}</td>
                <td class="Q-option"><input type="radio" id="contactChoice1" name="contact0${aa}" value="4" required/></td>
                <td class="Q-option"><input type="radio" id="contactChoice1" name="contact0${aa}" value="3" required/></td>
                <td class="Q-option"><input type="radio" id="contactChoice1" name="contact0${aa}" value="2" required/></td>
                <td class="Q-option"><input type="radio" id="contactChoice1" name="contact0${aa}" value="1" required/></td>
                <td class="Q-option"><input type="radio" id="contactChoice1" name="contact0${aa}" value="0" required/></td>
            </tr>
            `;
          });
          p_title.innerHTML = aaa+str;
          }

          function title2(arr) {
            // 抓取欄位
            const p_title = document.querySelector("#question_content2");
            let str = "";
            // 將資料存入
            let aa = 5;
            arr.forEach(function (data) {
              aaa=`
              <tr>
                      <td class="Q-title">　</td>
                      <td class="Q-option">隨時</td>
                      <td class="Q-option">大部分時間</td>
                      <td class="Q-option">約一半時間</td>
                      <td class="Q-option">偶爾</td>
                      <td class="Q-option">無</td>
                  </tr>
              `;
              aa++;
              str += 
              `<tr>
                  <td class="Q-title">${data.eye_question_content}</td>
                  <td class="Q-option"><input type="radio" id="contactChoice1" name="contact0${aa}" value="4" required/></td>
                  <td class="Q-option"><input type="radio" id="contactChoice1" name="contact0${aa}" value="3" required/></td>
                  <td class="Q-option"><input type="radio" id="contactChoice1" name="contact0${aa}" value="2" required/></td>
                  <td class="Q-option"><input type="radio" id="contactChoice1" name="contact0${aa}" value="1" required/></td>
                  <td class="Q-option"><input type="radio" id="contactChoice1" name="contact0${aa}" value="0" required/></td>
              </tr>
              `;
            });
            p_title.innerHTML = aaa+str;
            }
        }
    }
    );



    //把上一頁得到的分數加總
var getUrlString = location.href;  //取得網址
var url1 = new URL(getUrlString);  //將網址 (字串轉成URL)
var aa = url1.searchParams.get('contact01');  //取得網址裡01=?
var bb = url1.searchParams.get('contact02');  //取得網址裡02=?
var cc = url1.searchParams.get('contact03');  //取得網址裡03=?
var dd = url1.searchParams.get('contact04');  //取得網址裡04=?
var ee = url1.searchParams.get('contact05');  //取得網址裡05=?
var ff = url1.searchParams.get('contact06');  //取得網址裡06=?
var gg = url1.searchParams.get('contact07');  //取得網址裡07=?
var hh = url1.searchParams.get('contact08');  //取得網址裡08=?

var aa1 = parseInt(aa, 24);
var bb1 = parseInt(bb, 24);
var cc1 = parseInt(cc, 24);
var dd1 = parseInt(dd, 24);
var ee1 = parseInt(ee, 24);
var ff1 = parseInt(ff, 24);
var gg1 = parseInt(gg, 24);
var hh1 = parseInt(hh, 24);

var total = aa1+bb1+cc1+dd1+ee1+ff1+gg1+hh1;
console.log(total);
// alert(total);