/*************************************
author     : DK
createDate : 2010.1.1
editDate   : 2010.8.1,2010.8.16,2010.9.3,2010.9.10,2010.9.30
blog       : http://www.dklogs.net
email      : xiaobaov2@gmail.com
*************************************/
(
function () {
    if (!window.dk) { window['dk'] = {} }
    //根据ID获取对象
    function $() {
        if (typeof (arguments[0]) == 'string') {
            if (document.getElementById(arguments[0])) {
                return document.getElementById(arguments[0]);
            } else {
                throw "unknow element";
            }
        } else {
            return arguments[0];
        }
    }
    window.dk.$ = $;
    function $c(tagName) {
        return document.createElement(tagName);
    }
    window.dk.$c = $c;
    var browserMatch = window.dk.browserMatch = (function (ua) {
        ua = navigator.userAgent.toLowerCase();

        var match = /(webkit)[ \/]([\w.]+)/.exec(ua) ||
			/(opera)(?:.*version)?[ \/]([\w.]+)/.exec(ua) ||
			/(msie) ([\w.]+)/.exec(ua) ||
			!/compatible/.test(ua) && /(mozilla)(?:.*? rv:([\w.]+))?/.exec(ua) ||
		  	[];

        return { browser: match[1] || "", version: match[2] || "0" };
    })();
    window.dk.browser = {};
    if (browserMatch.browser) {
        window.dk.browser[browserMatch.browser] = true;
        window.dk.browser.version = browserMatch.version;
    }
    //根据Class名称获取对象
    function getElementsByClassName(className, tag, parent) {
        parent = parent || document;
        if (!(parent = $(parent))) { return false; }
        var allTags = (tag == '*' && parent.all) ? parent.all : parent.getElementsByTagName(tag);
        var matchingElements = new Array();
        className = className.replace(/\-/g, '\\-');
        var regex = new RegExp('(^|\\s)' + className + '(\\s|$)');
        var element;
        for (var i = 0, length = allTags.length; i < length; i++) {
            element = allTags[i];
            if (regex.test(element.className)) {
                matchingElements.push(element);
            }
        }
        return matchingElements;
    }
    window['dk']['getElementsByClassName'] = getElementsByClassName;
    //绑定事件
    function addEvent(node, type, listener) {
        if (!listener.$$guid) {
            listener.$$guid = addEvent.guid++;
        }
        if (!node.events) {
            node.events = {};
        }
        var handlers = node.events[type], isRegisted = !!node.events[type];
        if (!handlers) {
            handlers = node.events[type] = {};
        }
        handlers[listener.$$guid] = listener;
        if (!isRegisted) {
            if (node.addEventListener) {
                node.addEventListener(type, handleEvent, false);
            } else if (node.attachEvent) {
                var tempFunc = function () {
                    handleEvent.call(node, window.event);
                };
                node.attachEvent('on' + type, tempFunc);
            } else {
                node['on' + type] = handleEvent;
            }
        }
    }
    addEvent.guid = 1;
    function removeEvent(node, type, handler) {
        if (node.events && node.events[type]) {
            delete node.events[type][handler.$$guid];
        }
    }
    function handleEvent(event) {
        var returnValue = true;
        event = event || window.event;
        event = fixEvent(event, this);
        var handlers = this.events[event.type];
        for (var i in handlers) {
            this.$$handleEvent = handlers[i];
            if (this.$$handleEvent(event) === false) {
                returnValue = false;
            }
        }
        return returnValue;
    }
    function fixEvent(event, currentTarget) {
        event.preventDefault || (event.preventDefault = fixEvent.preventDefault);
        event.stopPropagation || (event.stopPropagation = fixEvent.stopPropagation);
        event.target || (event.target = event.srcElement);
        event.currentTarget || (event.currentTarget = currentTarget);
        //event.x && (event.x = fixEvent.x);
        //event.y && (event.y = fixEvent.y);
        return event;
    }
    fixEvent.preventDefault = function () {
        this.returnValue = false;
    };
    fixEvent.stopPropagation = function () {
        this.cancelBubble = true;
    };
    window['dk']['addEvent'] = addEvent;
    window.dk.addEvent = addEvent;
    //移出绑定的事件
    window.dk.removeEvent = removeEvent;
    //绑定函数的执行对象
    function bind(targetObj, func) {
        var args = Array.prototype.slice.call(arguments).slice(2);
        return function () {
            return func.apply(targetObj, args.concat(Array.prototype.slice.call(arguments)));
        }
    }
    window['dk']['bind'] = bind;
    //检查childNode是被包含在parentNode中
    function contains(parentNode, childNode) {
        return parentNode.contains ? parentNode != childNode && parentNode.contains(childNode) : !!(parentNode.compareDocumentPosition(childNode) & 16);
    }
    window['dk']['contains'] = contains;
    //获取Event对象
    function getEvent(e) {
        return e || window.event;
    }
    window.dk.getEvent = getEvent;
    //停止冒泡
    function stopBubble(e) {
        getEvent(e).bubbles ? getEvent(e).stopPropagation() : getEvent(e).cancelBubble = true;
    }
    window['dk']['stopBubble'] = stopBubble;
    //恢复冒泡
    function startBubble(e) {
        getEvent(e).initEvent ? getEvent(e).initEvent() : getEvent(e).cancelBubble = false;
    }
    window['dk']['startBubble'] = startBubble;
    //检查mouseover和mouseout模式下取消事件派发
    function checkHover(e, target) {
        if (dk.getEvent(e).type == "mouseover") {
            return !contains(target, getEvent(e).relatedTarget || getEvent(e).fromElement) && !((getEvent(e).relatedTarget || getEvent(e).fromElement) === target);
        }
        else {
            return !contains(target, getEvent(e).relatedTarget || getEvent(e).toElement) && !((getEvent(e).relatedTarget || getEvent(e).toElement) === target);
        }
    }
    window['dk']['checkHover'] = checkHover;
    //获取事件触发的对象
    function getEventTarget(e) {
        return dk.getEvent(e).target || dk.getEvent(e).srcElement;
    }
    window['dk']['getEventTarget'] = getEventTarget;
    //获取窗口的大小
    function getBrowserSize() {
        var de = document.documentElement;
        return {
            width: (window.innerWidth || (de && de.clientWidth) || document.body.clientWidth),
            height: (window.innerHeight || (de && de.clientHeight) || document.body.clientHeight)
        }
    }
    window['dk']['getBrowserSize'] = getBrowserSize;
    //获取对象在页面中的位置，返回值为值类型
    function getPositionInDoc(target) {
        (typeof target == 'string') && (target = document.getElementById(target));
        var left = 0, top = 0;
        do {
            left += target.offsetLeft || 0;
            top += target.offsetTop || 0;
            target = target.offsetParent;
        }
        while (target);
        return {
            left: left,
            top: top
        };
    }
    window['dk']['getPositionInDoc'] = getPositionInDoc;
    window.dk.pageDom = getPositionInDoc;
    //获取鼠标在Document中的位置，返回值为值类型
    function getMousePositionInDoc(e) {
        var scrollx, scrolly;
        if (typeof (window.pageXOffset) == 'number') {
            scrollx = window.pageXOffset;
            scrolly = window.pageYOffset;
        }
        else {
            scrollx = document.documentElement.scrollLeft;
            scrolly = document.documentElement.scrollTop;
        }
        return {
            x: e.clientX + scrollx,
            y: e.clientY + scrolly
        }
    }
    window['dk']['getMousePositionInDoc'] = getMousePositionInDoc;
    window['dk']['pageMouse'] = getMousePositionInDoc;
    window.dk.now = (function () { return new Date(); })();
    function tagName(target) {
        return target.tagName.toLowerCase();
    }
    window.dk.tagName = tagName;
    //日志
    function myLogs(id) {
        id = id || 'defaultDebugLogs';
        var logsWindow = null;
        var initWindow = function () {
            logsWindow = document.createElement('ol');
            logsWindow.setAttribute('id', id);
            var winStyle = logsWindow.style;
            winStyle.position = 'absolute';
            winStyle.top = '10px';
            winStyle.right = '10px';
            winStyle.width = '200px';
            winStyle.height = '300px';
            winStyle.border = '1px solid #ccc';
            winStyle.background = '#fff';
            winStyle.padding = 0;
            winStyle.margin = 0;
            document.body.appendChild(logsWindow);
        };
        this.writeRow = function (message) {
            logsWindow || initWindow();
            var newItem = document.createElement('li');
            newItem.style.padding = '2px';
            newItem.style.margin = '0 0 1px 0';
            newItem.style.background = '#eee';
            if (typeof (message) == 'undefined') {
                newItem.innerHTML = '<span style=\"color:#f90;\">Message is undefined</span>';
            }
            else {
                newItem.innerHTML = message;
            }
            logsWindow.appendChild(newItem);
        };
    }

    myLogs.prototype = {
        write: function (message) {

            if (typeof (message) == 'string' && message.length == 0) {
                return this.writeRow('<span style=\"color:#900;\">warning:</span> empty message');
            }
            if (typeof (message) != 'string' && typeof (message) != 'undefined') {
                if (message.toString) return this.writeRow(message.toString());
                else return this.writeRow(typeof (message));
            }
            if (typeof (message) == 'undefined') {
                return this.writeRow('<span style=\"color:#f90;\">Message is undefined</span>');
            }
            message = message.replace(/</g, "&lt;").replace(/</g, "&gt;");
            return this.writeRow(message);
        },
        header: function (message) {
            return this.writeRow(message);
        }
    };
    window.dk.logs = new myLogs('log');
    //Dom加载完成事件
    function ready(loadEvent) {
        var init = function () {
            if (arguments.callee.done)
                return;
            arguments.callee.done = true;
            loadEvent.apply(document, arguments);
        };

        if (document.addEventListener) {
            document.addEventListener('DOMContentLoaded', init, false);
        }

        if (/WebKit/i.test(navigator.userAgent)) {
            var _timer = setInterval(function () {
                if (/loaded|complete/.test(document.readyState)) {
                    clearInterval(_timer);
                    init();
                }
            }, 10)
        }


        /*@if(@_win32)*/
        document.write('<script id=__ie_onload defer src=javascript:void(0)><\/script>');
        var script = document.getElementById('__ie_onload');
        script.onreadystatechange = function () {
            if (this.readyState == 'complete') {
                init();
            }
        };
        /*@end @*/
        return true;
    }
    window['dk']['ready'] = ready;

    function trim(str) {
        return (str || "").replace(/^(\s|\u00A0)+|(\s|\u00A0)+$/g, "");
    }
    window['dk']['trim'] = trim;
})();

var _$ = function (node) {
    if (typeof (node) == 'string') {
        node = dk.$(node);
    }
    this.node = node;
};
_$.prototype = {
    fixover: function (func) {
        dk.addEvent(this.node, 'mouseover', function (e) {
            if (dk.checkHover(e, this)) {
                func(e);
            }
        });
        return this;
    },
    fixout: function (func) {
        dk.addEvent(this.node, 'mouseout', function (e) {
            if (dk.checkHover(e, this)) {
                func(e);
            }
        });
        return this;
    },
    css: function (style, value) {//三个重载方法
        var argNum = arguments.length;
        if (argNum == 1 && typeof (arguments[0]) == 'string') {//按照参数中的样式表的样式名称获取样式的值
            return this.getCss(arguments[0]);
        } else if (argNum == 1 && typeof (arguments[0]) == 'object') {//按照参数中的Json对象设置样式
            var styles = arguments[0];
            for (var i in styles) {
                this.setCss(i, styles[i]);
            }
        } else if (argNum == 2) {//按照参数中的样式名称和值对指定样式进行设置
            this.setCss(arguments[0], arguments[1]);
        }
        return this;
    },
    getCss: function (styleName) {
        if (this.node.currentStyle) {
            var value = this.node.currentStyle[styleName];
            if (value == 'auto' && styleName == 'width') {
                value = this.node.clientWidth;
            }
            if (value == 'auto' && styleName == 'height') {
                value = this.node.clientHeight;
            }
            return value;
        }
        else if (window.getComputedStyle) {
            var value = window.getComputedStyle(this.node, null).getPropertyValue(this.getSplitName(styleName));
            return value;
        }
    },
    width: function () {
        return this.node.offsetWidth;
    },
    height: function () {
        return this.node.offsetHeight;
    },
    setCss: function (styleName, value) {
        if (styleName == 'opacity' && document.body.filters) {
            this.node.style.filter = 'alpha(opacity=' + (parseFloat(value) * 100) + ')';
            return;
        }
        this.node.style[this.getCamelName(styleName)] = value;
    },
    getSplitName: function (styleName) {
        return styleName.replace(/([A-Z])/g, '-$1').toLowerCase();
    },
    getCamelName: function (style_name) {
        return style_name.replace(/-([a-z])/g, function (targetStr) {
            return targetStr.slice(1).toUpperCase();
        });
    },
    addClass: function (value) {
        var classNames = (value || '').split(/\s+/);
        if (this.node.className) {
            var className = ' ' + this.node.className + ' ', setClass = this.node.className;
            for (var i = 0, len = classNames.length; i < len; i++) {
                if (className.indexOf(' ' + classNames[i] + ' ') < 0) {
                    setClass += ' ' + classNames[i];
                }
            }
            this.node.className = dk.trim(setClass);
        } else {
            this.node.className = value;
        }
    },
    removeClass: function (value) {
        var classNames = (value || '').split(/\s+/);
        if (this.node.className) {
            if (value) {
                var className = (' ' + this.node.className + ' ').replace(/[\n\t]/g, ' ');
                for (var i = 0, len = classNames.length; i < len; i++) {
                    className = className.replace(' ' + classNames[i] + ' ', ' ');
                }
                this.node.className = dk.trim(className);
            } else {
                this.node.className = '';
            }
        }
    }
};
$$ = function (node) {
    return new _$(node);
};


/*************************************
作者：DK
时间：2010年9月11日
编辑：9.13
网址：http://www.dklogs.net
电子邮箱：xiaobaov2@gmail.com
*************************************/
var colorPicker = {
    currentInput: null,
    colorCode: null,
    callBackFuncs: [],
    hsv: { h: 0, s: 0, v: 1 },
    rgb: { r: 255, g: 255, b: 255 },
    setInputs: function (inputs) {
        var setInputValue = function (e) {
            colorPicker.render(dk.pageDom(this).left, dk.pageDom(this).top + $$(this).height());
            colorPicker.currentInput = this;
            colorPicker.callBackFuncs.length = 0;
            colorPicker.callBackFuncs.push(colorPicker.setColorCode);
        }
        for (var i = 0, len = inputs.length; i < len; i++) {
            dk.addEvent(dk.$(inputs[i]), 'click', setInputValue);
        }
    },
    init: function () {
        this.currentInput = null;
        this.colorCode = null;
        this.callBackFuncs.length = 0;
    },
    pickerDoms: {
        mainC: null, //color_picker container
        header: null, //header
        cpC: null, //color picker hsv container
        cpSV: null, //color picker sv container
        cpSVP: null, //color picker sv pointer
        cpH: null, //color picker h container
        cpHP: null, //color picker h pointer
        cpStatus: null, // color picker status
        cpColorCode: null, //current selected color code
        cpBgColor: null, //current selected color show as background
        cpFontColor: null, //current selected color show as font color
        cpBtnConfirm: null, // the confirm button
        cpBtnCancel: null//thie cancel button
    },
    eles: {
        div: document.createElement('DIV'),
        h2: document.createElement('H2'),
        span: document.createElement('SPAN'),
        input: document.createElement('INPUT')
    },
    initDom: function () {//initialization the color picker doms
        var mainC = this.pickerDoms.mainC = this.eles.div.cloneNode(true);
        mainC.setAttribute('id', 'dk_color_picker');
        var header = this.pickerDoms.header = this.eles.h2.cloneNode(true);
        var cpC = this.pickerDoms.cpC = this.eles.div.cloneNode(true);
        cpC.className = 'c_p_c clearfix';
        var cpSV = this.pickerDoms.cpSV = this.eles.div.cloneNode(true);
        cpSV.className = 'c_p_sv';
        var cpSVP = this.pickerDoms.cpSVP = this.eles.span.cloneNode(true);
        cpSVP.className = 'c_p_pointer';
        cpSV.appendChild(cpSVP);
        var cpH = this.pickerDoms.cpH = this.eles.div.cloneNode(true);
        cpH.className = 'c_p_h';
        var cpHP = this.pickerDoms.cpHP = this.eles.span.cloneNode(true);
        cpHP.className = 'c_p_h_pointer';
        cpH.appendChild(cpHP);
        cpC.appendChild(cpSV);
        cpC.appendChild(cpH);
        //handle the status doms
        var cpStatus = this.pickerDoms.cpStatus = this.eles.div.cloneNode(true);
        cpStatus.className = 'c_p_status';
        var cpColorCode = this.pickerDoms.cpColorCode = this.eles.span.cloneNode(true);
        var cpBgColor = this.pickerDoms.cpBgColor = this.eles.span.cloneNode(true);
        cpBgColor.innerHTML = '&nbsp;';
        var cpFontColor = this.pickerDoms.cpFontColor = this.eles.span.cloneNode(true);
        cpFontColor.innerHTML = '选定的颜色';
        var cpBtnConfirm = this.pickerDoms.cpBtnConfirm = this.eles.input.cloneNode(true);
        cpBtnConfirm.setAttribute('type', 'button');
        cpBtnConfirm.setAttribute('value', '确定');
        var cpBtnCancel = this.pickerDoms.cpBtnCancel = this.eles.input.cloneNode(true);
        cpBtnCancel.setAttribute('type', 'button');
        cpBtnCancel.setAttribute('value', '取消');
        cpStatus.appendChild(cpColorCode);
        cpStatus.appendChild(cpBgColor);
        cpStatus.appendChild(cpFontColor);
        cpStatus.appendChild(cpBtnConfirm);
        cpStatus.appendChild(cpBtnCancel);
        mainC.appendChild(header);
        mainC.appendChild(cpC);
        mainC.appendChild(cpStatus);
        document.body.appendChild(mainC);
    },
    initEvent: function () {
        dk.addEvent(this.pickerDoms.cpSV, 'click', colorPicker.setSVPointer);
        dk.addEvent(this.pickerDoms.cpH, 'click', colorPicker.setHPointer);
        dk.addEvent(this.pickerDoms.cpBtnConfirm, 'click', colorPicker.confirBtnEvent);
        dk.addEvent(this.pickerDoms.cpBtnCancel, 'click', colorPicker.cancelBtnEvent);
    },
    render: function (left, top) {
        this.init();
        colorPicker.pickerDoms.mainC || this.initDom();
        this.initEvent();
        $$(colorPicker.pickerDoms.mainC).css({ left: left + 'px', top: top + 'px', display: 'block' });
    },
    hsv2rgb: function (h, s, v) {//h:色相，s:饱和度，v:亮度 http://www.easyrgb.com/
        var r, g, b;
        if (s == 0) {
            r = v * 255;
            g = v * 255;
            b = v * 255;
        }
        else {
            var tempH = h * 6;
            if (tempH == 6) {
                tempH = 0;
            }
            tempI = Math.floor(tempH);
            temp_1 = v * (1 - s);
            temp_2 = v * (1 - s * (tempH - tempI));
            temp_3 = v * (1 - s * (1 - (tempH - tempI)));
            switch (tempI) {
                case 0:
                    r = v;
                    g = temp_3;
                    b = temp_1;
                    break;
                case 1:
                    r = temp_2;
                    g = v;
                    b = temp_1;
                    break;
                case 2:
                    r = temp_1;
                    g = v;
                    b = temp_3;
                    break;
                case 3:
                    r = temp_1;
                    g = temp_2;
                    b = v;
                    break;
                case 4:
                    r = temp_3;
                    g = temp_1;
                    b = v;
                    break;
                default:
                    r = v;
                    g = temp_1;
                    b = temp_2;
                    break;
            }
            r = r * 255;
            b = b * 255;
            g = g * 255;
        }
        return {
            r: Math.ceil(r),
            g: Math.ceil(g),
            b: Math.ceil(b)
        };
    },
    getColorCode: function (hsv) {//json格式{h,s,v}
        var rgb = this.hsv2rgb(hsv.h, hsv.s, hsv.v);
        function getPerColor(num) {
            var num16 = num.toString(16);
            if (num16.length == 1) {
                return '0' + num16;
            } else {
                return num16;
            }
        }
        return '#' + getPerColor(rgb.r) + getPerColor(rgb.g) + getPerColor(rgb.b);
    },
    setColorCode: function () {
        colorPicker.currentInput.value = colorPicker.colorCode;
    },
    excuteCallBack: function () {
        for (var i = 0, len = colorPicker.callBackFuncs.length; i < len; i++) {
            colorPicker.callBackFuncs[i]();
        }
    },
    confirBtnEvent: function (e) {
        colorPicker.colorCode = colorPicker.getColorCode(colorPicker.hsv);
        //colorPicker.currentInput && colorPicker.setColorCode();
        //colorPicker.callBackStatus && colorPicker.excuteCallBack();
        if (colorPicker.callBackFuncs.length > 0) {
            colorPicker.excuteCallBack();
        }
        colorPicker.dispose();
    },
    cancelBtnEvent: function (e) {
        colorPicker.dispose();
    },
    dispose: function () {//待改进
        colorPicker.pickerDoms.mainC.style.display = 'none';
    },
    setSVPointer: function (e) {
        var relativeX = dk.pageMouse(e).x - dk.pageDom(colorPicker.pickerDoms.cpSV).left;
        var relativeY = dk.pageMouse(e).y - dk.pageDom(colorPicker.pickerDoms.cpSV).top;
        colorPicker.hsv.s = relativeX / 255;
        colorPicker.hsv.v = (255 - relativeY) / 255;
        var colorCode = colorPicker.getColorCode(colorPicker.hsv);

        colorPicker.pickerDoms.cpSVP.style.left = (relativeX - 8) + 'px';
        colorPicker.pickerDoms.cpSVP.style.top = (relativeY - 8) + 'px';

        colorPicker.setStatus(colorCode);
    },
    setHPointer: function (e) {
        var relativeX = dk.pageMouse(e).x - dk.pageDom(colorPicker.pickerDoms.cpH).left;
        var relativeY = dk.pageMouse(e).y - dk.pageDom(colorPicker.pickerDoms.cpH).top;
        colorPicker.hsv.h = (255 - relativeY) / 255;
        colorPicker.pickerDoms.cpHP.style.top = (relativeY - 4) + 'px';
        colorPicker.pickerDoms.cpSV.style.backgroundColor = colorPicker.getColorCode({ h: colorPicker.hsv.h, s: 1, v: 1 });
        var colorCode = colorPicker.getColorCode(colorPicker.hsv);
        colorPicker.setStatus(colorCode);
    },
    setStatus: function (colorCode) {
        colorPicker.pickerDoms.cpColorCode.innerHTML = colorCode;
        colorPicker.pickerDoms.cpBgColor.style.backgroundColor = colorCode;
        colorPicker.pickerDoms.cpFontColor.style.color = colorCode;
    }
}


