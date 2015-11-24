/** vim: et:ts=4:sw=4:sts=4
 * @license RequireJS 2.1.9 Copyright (c) 2010-2012, The Dojo Foundation All Rights Reserved.
 * Available via the MIT or new BSD license.
 * see: http://github.com/jrburke/requirejs for details
 */

var requirejs, require, define; !
function (global) {
    function isFunction(e) {
        return "[object Function]" === ostring.call(e)
    }
    function isArray(e) {
        return "[object Array]" === ostring.call(e)
    }
    function each(e, t) {
        if (e) {
            var i;
            for (i = 0; i < e.length && (!e[i] || !t(e[i], i, e)) ; i += 1);
        }
    }
    function eachReverse(e, t) {
        if (e) {
            var i;
            for (i = e.length - 1; i > -1 && (!e[i] || !t(e[i], i, e)) ; i -= 1);
        }
    }
    function hasProp(e, t) {
        return hasOwn.call(e, t)
    }
    function getOwn(e, t) {
        return hasProp(e, t) && e[t]
    }
    function eachProp(e, t) {
        var i;
        for (i in e) if (hasProp(e, i) && t(e[i], i)) break
    }
    function mixin(e, t, i, r) {
        return t && eachProp(t,
        function (t, n) {
            (i || !hasProp(e, n)) && (r && "string" != typeof t ? (e[n] || (e[n] = {}), mixin(e[n], t, i, r)) : e[n] = t)
        }),
        e
    }
    function bind(e, t) {
        return function () {
            return t.apply(e, arguments)
        }
    }
    function scripts() {
        return document.getElementsByTagName("script")
    }
    function defaultOnError(e) {
        throw e
    }
    function getGlobal(e) {
        if (!e) return e;
        var t = global;
        return each(e.split("."),
        function (e) {
            t = t[e]
        }),
        t
    }
    function makeError(e, t, i, r) {
        var n = new Error(t + "\nhttp://requirejs.org/docs/errors.html#" + e);
        return n.requireType = e,
        n.requireModules = r,
        i && (n.originalError = i),
        n
    }
    function newContext(e) {
        function t(e) {
            var t, i;
            for (t = 0; e[t]; t += 1) if (i = e[t], "." === i) e.splice(t, 1),
            t -= 1;
            else if (".." === i) {
                if (1 === t && (".." === e[2] || ".." === e[0])) break;
                t > 0 && (e.splice(t - 1, 2), t -= 2)
            }
        }
        function i(e, i, r) {
            var n, a, o, s, c, u, p, d, f, l, h, m = i && i.split("/"),
            g = m,
            v = y.map,
            x = v && v["*"];
            if (e && "." === e.charAt(0) && (i ? (g = getOwn(y.pkgs, i) ? m = [i] : m.slice(0, m.length - 1), e = g.concat(e.split("/")), t(e), a = getOwn(y.pkgs, n = e[0]), e = e.join("/"), a && e === n + "/" + a.main && (e = n)) : 0 === e.indexOf("./") && (e = e.substring(2))), r && v && (m || x)) {
                for (s = e.split("/"), c = s.length; c > 0; c -= 1) {
                    if (p = s.slice(0, c).join("/"), m) for (u = m.length; u > 0; u -= 1) if (o = getOwn(v, m.slice(0, u).join("/")), o && (o = getOwn(o, p))) {
                        d = o,
                        f = c;
                        break
                    }
                    if (d) break; !l && x && getOwn(x, p) && (l = getOwn(x, p), h = c)
                } !d && l && (d = l, f = h),
                d && (s.splice(0, f, d), e = s.join("/"))
            }
            return e
        }
        function r(e) {
            isBrowser && each(scripts(),
            function (t) {
                return t.getAttribute("data-requiremodule") === e && t.getAttribute("data-requirecontext") === q.contextName ? (t.parentNode.removeChild(t), !0) : void 0
            })
        }
        function n(e) {
            var t = getOwn(y.paths, e);
            return t && isArray(t) && t.length > 1 ? (t.shift(), q.require.undef(e), q.require([e]), !0) : void 0
        }
        function a(e) {
            var t, i = e ? e.indexOf("!") : -1;
            return i > -1 && (t = e.substring(0, i), e = e.substring(i + 1, e.length)),
            [t, e]
        }
        function o(e, t, r, n) {
            var o, s, c, u, p = null,
            d = t ? t.name : null,
            f = e,
            l = !0,
            h = "";
            return e || (l = !1, e = "_@r" + (A += 1)),
            u = a(e),
            p = u[0],
            e = u[1],
            p && (p = i(p, d, n), s = getOwn(j, p)),
            e && (p ? h = s && s.normalize ? s.normalize(e,
            function (e) {
                return i(e, d, n)
            }) : i(e, d, n) : (h = i(e, d, n), u = a(h), p = u[0], h = u[1], r = !0, o = q.nameToUrl(h))),
            c = !p || s || r ? "" : "_unnormalized" + (R += 1),
            {
                prefix: p,
                name: h,
                parentMap: t,
                unnormalized: !!c,
                url: o,
                originalName: f,
                isDefine: l,
                id: (p ? p + "!" + h : h) + c
            }
        }
        function s(e) {
            var t = e.id,
            i = getOwn(k, t);
            return i || (i = k[t] = new q.Module(e)),
            i
        }
        function c(e, t, i) {
            var r = e.id,
            n = getOwn(k, r); !hasProp(j, r) || n && !n.defineEmitComplete ? (n = s(e), n.error && "error" === t ? i(n.error) : n.on(t, i)) : "defined" === t && i(j[r])
        }
        function u(e, t) {
            var i = e.requireModules,
            r = !1;
            t ? t(e) : (each(i,
            function (t) {
                var i = getOwn(k, t);
                i && (i.error = e, i.events.error && (r = !0, i.emit("error", e)))
            }), r || req.onError(e))
        }
        function p() {
            globalDefQueue.length && (apsp.apply(M, [M.length - 1, 0].concat(globalDefQueue)), globalDefQueue = [])
        }
        function d(e) {
            delete k[e],
            delete S[e]
        }
        function f(e, t, i) {
            var r = e.map.id;
            e.error ? e.emit("error", e.error) : (t[r] = !0, each(e.depMaps,
            function (r, n) {
                var a = r.id,
                o = getOwn(k, a); !o || e.depMatched[n] || i[a] || (getOwn(t, a) ? (e.defineDep(n, j[a]), e.check()) : f(o, t, i))
            }), i[r] = !0)
        }
        function l() {
            var e, t, i, a, o = 1e3 * y.waitSeconds,
            s = o && q.startTime + o < (new Date).getTime(),
            c = [],
            p = [],
            d = !1,
            h = !0;
            if (!x) {
                if (x = !0, eachProp(S,
                function (i) {
                  if (e = i.map, t = e.id, i.enabled && (e.isDefine || p.push(i), !i.error)) if (!i.inited && s) n(t) ? (a = !0, d = !0) : (c.push(t), r(t));
                else if (!i.inited && i.fetched && e.isDefine && (d = !0, !e.prefix)) return h = !1
                }), s && c.length) return i = makeError("timeout", "Load timeout for modules: " + c, null, c),
                i.contextName = q.contextName,
                u(i);
                h && each(p,
                function (e) {
                    f(e, {},
                    {})
                }),
                s && !a || !d || !isBrowser && !isWebWorker || w || (w = setTimeout(function () {
                    w = 0,
                    l()
                },
                50)),
                x = !1
            }
        }
        function h(e) {
            hasProp(j, e[0]) || s(o(e[0], null, !0)).init(e[1], e[2])
        }
        function m(e, t, i, r) {
            e.detachEvent && !isOpera ? r && e.detachEvent(r, t) : e.removeEventListener(i, t, !1)
        }
        function g(e) {
            var t = e.currentTarget || e.srcElement;
            return m(t, q.onScriptLoad, "load", "onreadystatechange"),
            m(t, q.onScriptError, "error"),
            {
                node: t,
                id: t && t.getAttribute("data-requiremodule")
            }
        }
        function v() {
            var e;
            for (p() ; M.length;) {
                if (e = M.shift(), null === e[0]) return u(makeError("mismatch", "Mismatched anonymous define() module: " + e[e.length - 1]));
                h(e)
            }
        }
        var x, b, q, E, w, y = {
            waitSeconds: 7,
            baseUrl: "./",
            paths: {},
            pkgs: {},
            shim: {},
            config: {}
        },
        k = {},
        S = {},
        O = {},
        M = [],
        j = {},
        P = {},
        A = 1,
        R = 1;
        return E = {
            require: function (e) {
                return e.require ? e.require : e.require = q.makeRequire(e.map)
            },
            exports: function (e) {
                return e.usingExports = !0,
                e.map.isDefine ? e.exports ? e.exports : e.exports = j[e.map.id] = {} : void 0
            },
            module: function (e) {
                return e.module ? e.module : e.module = {
                    id: e.map.id,
                    uri: e.map.url,
                    config: function () {
                        var t, i = getOwn(y.pkgs, e.map.id);
                        return t = i ? getOwn(y.config, e.map.id + "/" + i.main) : getOwn(y.config, e.map.id),
                        t || {}
                    },
                    exports: j[e.map.id]
                }
            }
        },
        b = function (e) {
            this.events = getOwn(O, e.id) || {},
            this.map = e,
            this.shim = getOwn(y.shim, e.id),
            this.depExports = [],
            this.depMaps = [],
            this.depMatched = [],
            this.pluginMaps = {},
            this.depCount = 0
        },
        b.prototype = {
            init: function (e, t, i, r) {
                r = r || {},
                this.inited || (this.factory = t, i ? this.on("error", i) : this.events.error && (i = bind(this,
                function (e) {
                    this.emit("error", e)
                })), this.depMaps = e && e.slice(0), this.errback = i, this.inited = !0, this.ignore = r.ignore, r.enabled || this.enabled ? this.enable() : this.check())
            },
            defineDep: function (e, t) {
                this.depMatched[e] || (this.depMatched[e] = !0, this.depCount -= 1, this.depExports[e] = t)
            },
            fetch: function () {
                if (!this.fetched) {
                    this.fetched = !0,
                    q.startTime = (new Date).getTime();
                    var e = this.map;
                    return this.shim ? (q.makeRequire(this.map, {
                        enableBuildCallback: !0
                    })(this.shim.deps || [], bind(this,
                    function () {
                        return e.prefix ? this.callPlugin() : this.load()
                    })), void 0) : e.prefix ? this.callPlugin() : this.load()
                }
            },
            load: function () {
                var e = this.map.url;
                P[e] || (P[e] = !0, q.load(this.map.id, e))
            },
            check: function () {
                if (this.enabled && !this.enabling) {
                    var e, t, i = this.map.id,
                    r = this.depExports,
                    n = this.exports,
                    a = this.factory;
                    if (this.inited) {
                        if (this.error) this.emit("error", this.error);
                        else if (!this.defining) {
                            if (this.defining = !0, this.depCount < 1 && !this.defined) {
                                if (isFunction(a)) {
                                    if (this.events.error && this.map.isDefine || req.onError !== defaultOnError) try {
                                        n = q.execCb(i, a, r, n)
                                    } catch (o) {
                                        e = o
                                    } else n = q.execCb(i, a, r, n);
                                    if (this.map.isDefine && (t = this.module, t && void 0 !== t.exports && t.exports !== this.exports ? n = t.exports : void 0 === n && this.usingExports && (n = this.exports)), e) return e.requireMap = this.map,
                                    e.requireModules = this.map.isDefine ? [this.map.id] : null,
                                    e.requireType = this.map.isDefine ? "define" : "require",
                                    u(this.error = e)
                                } else n = a;
                                this.exports = n,
                                this.map.isDefine && !this.ignore && (j[i] = n, req.onResourceLoad && req.onResourceLoad(q, this.map, this.depMaps)),
                                d(i),
                                this.defined = !0
                            }
                            this.defining = !1,
                            this.defined && !this.defineEmitted && (this.defineEmitted = !0, this.emit("defined", this.exports), this.defineEmitComplete = !0)
                        }
                    } else this.fetch()
                }
            },
            callPlugin: function () {
                var e = this.map,
                t = e.id,
                r = o(e.prefix);
                this.depMaps.push(r),
                c(r, "defined", bind(this,
                function (r) {
                    var n, a, p, f = this.map.name,
                    l = this.map.parentMap ? this.map.parentMap.name : null,
                    h = q.makeRequire(e.parentMap, {
                        enableBuildCallback: !0
                    });
                    return this.map.unnormalized ? (r.normalize && (f = r.normalize(f,
                    function (e) {
                        return i(e, l, !0)
                    }) || ""), a = o(e.prefix + "!" + f, this.map.parentMap), c(a, "defined", bind(this,
                    function (e) {
                        this.init([],
                        function () {
                            return e
                        },
                        null, {
                            enabled: !0,
                            ignore: !0
                        })
                    })), p = getOwn(k, a.id), p && (this.depMaps.push(a), this.events.error && p.on("error", bind(this,
                    function (e) {
                        this.emit("error", e)
                    })), p.enable()), void 0) : (n = bind(this,
                    function (e) {
                        this.init([],
                        function () {
                            return e
                        },
                        null, {
                            enabled: !0
                        })
                    }), n.error = bind(this,
                    function (e) {
                        this.inited = !0,
                        this.error = e,
                        e.requireModules = [t],
                        eachProp(k,
                        function (e) {
                            0 === e.map.id.indexOf(t + "_unnormalized") && d(e.map.id)
                        }),
                        u(e)
                    }), n.fromText = bind(this,
                    function (i, r) {
                        var a = e.name,
                        c = o(a),
                        p = useInteractive;
                        r && (i = r),
                        p && (useInteractive = !1),
                        s(c),
                        hasProp(y.config, t) && (y.config[a] = y.config[t]);
                        try {
                            req.exec(i)
                        } catch (d) {
                            return u(makeError("fromtexteval", "fromText eval for " + t + " failed: " + d, d, [t]))
                        }
                        p && (useInteractive = !0),
                        this.depMaps.push(c),
                        q.completeLoad(a),
                        h([a], n)
                    }), r.load(e.name, h, n, y), void 0)
                })),
                q.enable(r, this),
                this.pluginMaps[r.id] = r
            },
            enable: function () {
                S[this.map.id] = this,
                this.enabled = !0,
                this.enabling = !0,
                each(this.depMaps, bind(this,
                function (e, t) {
                    var i, r, n;
                    if ("string" == typeof e) {
                        if (e = o(e, this.map.isDefine ? this.map : this.map.parentMap, !1, !this.skipMap), this.depMaps[t] = e, n = getOwn(E, e.id)) return this.depExports[t] = n(this),
                        void 0;
                        this.depCount += 1,
                        c(e, "defined", bind(this,
                        function (e) {
                            this.defineDep(t, e),
                            this.check()
                        })),
                        this.errback && c(e, "error", bind(this, this.errback))
                    }
                    i = e.id,
                    r = k[i],
                    hasProp(E, i) || !r || r.enabled || q.enable(e, this)
                })),
                eachProp(this.pluginMaps, bind(this,
                function (e) {
                    var t = getOwn(k, e.id);
                    t && !t.enabled && q.enable(e, this)
                })),
                this.enabling = !1,
                this.check()
            },
            on: function (e, t) {
                var i = this.events[e];
                i || (i = this.events[e] = []),
                i.push(t)
            },
            emit: function (e, t) {
                each(this.events[e],
                function (e) {
                    e(t)
                }),
                "error" === e && delete this.events[e]
            }
        },
        q = {
            config: y,
            contextName: e,
            registry: k,
            defined: j,
            urlFetched: P,
            defQueue: M,
            Module: b,
            makeModuleMap: o,
            nextTick: req.nextTick,
            onError: u,
            configure: function (e) {
                e.baseUrl && "/" !== e.baseUrl.charAt(e.baseUrl.length - 1) && (e.baseUrl += "/");
                var t = y.pkgs,
                i = y.shim,
                r = {
                    paths: !0,
                    config: !0,
                    map: !0
                };
                eachProp(e,
                function (e, t) {
                    r[t] ? "map" === t ? (y.map || (y.map = {}), mixin(y[t], e, !0, !0)) : mixin(y[t], e, !0) : y[t] = e
                }),
                e.shim && (eachProp(e.shim,
                function (e, t) {
                    isArray(e) && (e = {
                        deps: e
                    }),
                    !e.exports && !e.init || e.exportsFn || (e.exportsFn = q.makeShimExports(e)),
                    i[t] = e
                }), y.shim = i),
                e.packages && (each(e.packages,
                function (e) {
                    var i;
                    e = "string" == typeof e ? {
                        name: e
                    } : e,
                    i = e.location,
                    t[e.name] = {
                        name: e.name,
                        location: i || e.name,
                        main: (e.main || "main").replace(currDirRegExp, "").replace(jsSuffixRegExp, "")
                    }
                }), y.pkgs = t),
                eachProp(k,
                function (e, t) {
                    e.inited || e.map.unnormalized || (e.map = o(t))
                }),
                (e.deps || e.callback) && q.require(e.deps || [], e.callback)
            },
            makeShimExports: function (e) {
                function t() {
                    var t;
                    return e.init && (t = e.init.apply(global, arguments)),
                    t || e.exports && getGlobal(e.exports)
                }
                return t
            },
            makeRequire: function (t, n) {
                function a(i, r, c) {
                    var p, d, f;
                    return n.enableBuildCallback && r && isFunction(r) && (r.__requireJsBuild = !0),
                    "string" == typeof i ? isFunction(r) ? u(makeError("requireargs", "Invalid require call"), c) : t && hasProp(E, i) ? E[i](k[t.id]) : req.get ? req.get(q, i, t, a) : (d = o(i, t, !1, !0), p = d.id, hasProp(j, p) ? j[p] : u(makeError("notloaded", 'Module name "' + p + '" has not been loaded yet for context: ' + e + (t ? "" : ". Use require([])")))) : (v(), q.nextTick(function () {
                        v(),
                        f = s(o(null, t)),
                        f.skipMap = n.skipMap,
                        f.init(i, r, c, {
                            enabled: !0
                        }),
                        l()
                    }), a)
                }
                return n = n || {},
                mixin(a, {
                    isBrowser: isBrowser,
                    toUrl: function (e) {
                        var r, n = e.lastIndexOf("."),
                        a = e.split("/")[0],
                        o = "." === a || ".." === a;
                        return -1 !== n && (!o || n > 1) && (r = e.substring(n, e.length), e = e.substring(0, n)),
                        q.nameToUrl(i(e, t && t.id, !0), r, !0)
                    },
                    defined: function (e) {
                        return hasProp(j, o(e, t, !1, !0).id)
                    },
                    specified: function (e) {
                        return e = o(e, t, !1, !0).id,
                        hasProp(j, e) || hasProp(k, e)
                    }
                }),
                t || (a.undef = function (e) {
                    p();
                    var i = o(e, t, !0),
                    n = getOwn(k, e);
                    r(e),
                    delete j[e],
                    delete P[i.url],
                    delete O[e],
                    n && (n.events.defined && (O[e] = n.events), d(e))
                }),
                a
            },
            enable: function (e) {
                var t = getOwn(k, e.id);
                t && s(e).enable()
            },
            completeLoad: function (e) {
                var t, i, r, a = getOwn(y.shim, e) || {},
                o = a.exports;
                for (p() ; M.length;) {
                    if (i = M.shift(), null === i[0]) {
                        if (i[0] = e, t) break;
                        t = !0
                    } else i[0] === e && (t = !0);
                    h(i)
                }
                if (r = getOwn(k, e), !t && !hasProp(j, e) && r && !r.inited) {
                    if (!(!y.enforceDefine || o && getGlobal(o))) return n(e) ? void 0 : u(makeError("nodefine", "No define call for " + e, null, [e]));
                    h([e, a.deps || [], a.exportsFn])
                }
                l()
            },
            nameToUrl: function (e, t, i) {
                var r, n, a, o, s, c, u, p, d;
                if (req.jsExtRegExp.test(e)) p = e + (t || "");
                else {
                    for (r = y.paths, n = y.pkgs, s = e.split("/"), c = s.length; c > 0; c -= 1) {
                        if (u = s.slice(0, c).join("/"), a = getOwn(n, u), d = getOwn(r, u)) {
                            isArray(d) && (d = d[0]),
                            s.splice(0, c, d);
                            break
                        }
                        if (a) {
                            o = e === a.name ? a.location + "/" + a.main : a.location,
                            s.splice(0, c, o);
                            break
                        }
                    }
                    p = s.join("/"),
                    p += t || (/^data\:|\?/.test(p) || i ? "" : ".js"),
                    p = ("/" === p.charAt(0) || p.match(/^[\w\+\.\-]+:/) ? "" : y.baseUrl) + p
                }
                return y.urlArgs ? p + ((-1 === p.indexOf("?") ? "?" : "&") + y.urlArgs) : p
            },
            load: function (e, t) {
                req.load(q, e, t)
            },
            execCb: function (e, t, i, r) {
                return t.apply(r, i)
            },
            onScriptLoad: function (e) {
                if ("load" === e.type || readyRegExp.test((e.currentTarget || e.srcElement).readyState)) {
                    interactiveScript = null;
                    var t = g(e);
                    q.completeLoad(t.id)
                }
            },
            onScriptError: function (e) {
                var t = g(e);
                return n(t.id) ? void 0 : u(makeError("scripterror", "Script error for: " + t.id, e, [t.id]))
            }
        },
        q.require = q.makeRequire(),
        q
    }
    function getInteractiveScript() {
        return interactiveScript && "interactive" === interactiveScript.readyState ? interactiveScript : (eachReverse(scripts(),
        function (e) {
            return "interactive" === e.readyState ? interactiveScript = e : void 0
        }), interactiveScript)
    }
    var req, s, head, baseElement, dataMain, src, interactiveScript, currentlyAddingScript, mainScript, subPath, version = "2.1.9",
    commentRegExp = /(\/\*([\s\S]*?)\*\/|([^:]|^)\/\/(.*)$)/gm,
    cjsRequireRegExp = /[^.]\s*require\s*\(\s*["']([^'"\s]+)["']\s*\)/g,
    jsSuffixRegExp = /\.js$/,
    currDirRegExp = /^\.\//,
    op = Object.prototype,
    ostring = op.toString,
    hasOwn = op.hasOwnProperty,
    ap = Array.prototype,
    apsp = ap.splice,
    isBrowser = !("undefined" == typeof window || "undefined" == typeof navigator || !window.document),
    isWebWorker = !isBrowser && "undefined" != typeof importScripts,
    readyRegExp = isBrowser && "PLAYSTATION 3" === navigator.platform ? /^complete$/ : /^(complete|loaded)$/,
    defContextName = "_",
    isOpera = "undefined" != typeof opera && "[object Opera]" === opera.toString(),
    contexts = {},
    cfg = {},
    globalDefQueue = [],
    useInteractive = !1;
    if ("undefined" == typeof define) {
        if ("undefined" != typeof requirejs) {
            if (isFunction(requirejs)) return;
            cfg = requirejs,
            requirejs = void 0
        }
        "undefined" == typeof require || isFunction(require) || (cfg = require, require = void 0),
        req = requirejs = function (e, t, i, r) {
            var n, a, o = defContextName;
            return isArray(e) || "string" == typeof e || (a = e, isArray(t) ? (e = t, t = i, i = r) : e = []),
            a && a.context && (o = a.context),
            n = getOwn(contexts, o),
            n || (n = contexts[o] = req.s.newContext(o)),
            a && n.configure(a),
            n.require(e, t, i)
        },
        req.config = function (e) {
            return req(e)
        },
        req.nextTick = "undefined" != typeof setTimeout ?
        function (e) {
            setTimeout(e, 4)
        } : function (e) {
            e()
        },
        require || (require = req),
        req.version = version,
        req.jsExtRegExp = /^\/|:|\?|\.js$/,
        req.isBrowser = isBrowser,
        s = req.s = {
            contexts: contexts,
            newContext: newContext
        },
        req({}),
        each(["toUrl", "undef", "defined", "specified"],
        function (e) {
            req[e] = function () {
                var t = contexts[defContextName];
                return t.require[e].apply(t, arguments)
            }
        }),
        isBrowser && (head = s.head = document.getElementsByTagName("head")[0], baseElement = document.getElementsByTagName("base")[0], baseElement && (head = s.head = baseElement.parentNode)),
        req.onError = defaultOnError,
        req.createNode = function (e) {
            var t = e.xhtml ? document.createElementNS("http://www.w3.org/1999/xhtml", "html:script") : document.createElement("script");
            return t.type = e.scriptType || "text/javascript",
            t.charset = "utf-8",
            t.async = !0,
            t
        },
        req.load = function (e, t, i) {
            var r, n = e && e.config || {};
            if (isBrowser) return r = req.createNode(n, t, i),
            r.setAttribute("data-requirecontext", e.contextName),
            r.setAttribute("data-requiremodule", t),
            !r.attachEvent || r.attachEvent.toString && r.attachEvent.toString().indexOf("[native code") < 0 || isOpera ? (r.addEventListener("load", e.onScriptLoad, !1), r.addEventListener("error", e.onScriptError, !1)) : (useInteractive = !0, r.attachEvent("onreadystatechange", e.onScriptLoad)),
            r.src = i,
            currentlyAddingScript = r,
            baseElement ? head.insertBefore(r, baseElement) : head.appendChild(r),
            currentlyAddingScript = null,
            r;
            if (isWebWorker) try {
                importScripts(i),
                e.completeLoad(t)
            } catch (a) {
                e.onError(makeError("importscripts", "importScripts failed for " + t + " at " + i, a, [t]))
            }
        },
        isBrowser && !cfg.skipDataMain && eachReverse(scripts(),
        function (e) {
            return head || (head = e.parentNode),
            dataMain = e.getAttribute("data-main"),
            dataMain ? (mainScript = dataMain, cfg.baseUrl || (src = mainScript.split("/"), mainScript = src.pop(), subPath = src.length ? src.join("/") + "/" : "./", cfg.baseUrl = subPath), mainScript = mainScript.replace(jsSuffixRegExp, ""), req.jsExtRegExp.test(mainScript) && (mainScript = dataMain), cfg.deps = cfg.deps ? cfg.deps.concat(mainScript) : [mainScript], !0) : void 0
        }),
        define = function (e, t, i) {
            var r, n;
            "string" != typeof e && (i = t, t = e, e = null),
            isArray(t) || (i = t, t = null),
            !t && isFunction(i) && (t = [], i.length && (i.toString().replace(commentRegExp, "").replace(cjsRequireRegExp,
            function (e, i) {
                t.push(i)
            }), t = (1 === i.length ? ["require"] : ["require", "exports", "module"]).concat(t))),
            useInteractive && (r = currentlyAddingScript || getInteractiveScript(), r && (e || (e = r.getAttribute("data-requiremodule")), n = contexts[r.getAttribute("data-requirecontext")])),
            (n ? n.defQueue : globalDefQueue).push([e, t, i])
        },
        define.amd = {
            jQuery: !0
        },
        req.exec = function (text) {
            return eval(text)
        },
        req(cfg)
    }
}(this);