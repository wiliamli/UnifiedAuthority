webpackJsonp([3], {
    VAuT: function (t, e, n) {
        "use strict";
        Object.defineProperty(e, "__esModule", {
            value: !0
        });
        var a = n("u4Bs"), param,
            r = {
                data: function () {
                    var t = this;
                    return {
                        listColumns: [{
                            title: "序号",
                            key: "ServiceNumber",
                            align: "center",
                            width: 150
                        },
                        {
                            title: "系统标识",
                            key: "ServiceSign",
                            align: "center"
                        },
                        {
                            title: "系统URL",
                            key: "url",
                            align: "center"
                        },
                        {
                            title: "备注",
                            key: "ServiceName",
                            align: "center"
                        },
                        {
                            title: "操作",
                            key: "action",
                            align: "center",
                            render: function (e, n) {
                                return e("div", [e("Button", {
                                    props: {
                                        type: "text",
                                        size: "small"
                                    },
                                    on: {
                                        click: function () {
                                            t.toPath("/menu/" + n.row.ServiceNumber)
                                        }
                                    }
                                },
                                    "菜单管理"), e("Button", {
                                        props: {
                                            type: "text",
                                            size: "small"
                                        },
                                        on: {
                                            click: function () {
                                                t.toPath("/user/" + n.row.ServiceNumber)
                                            }
                                        }
                                    },
                                        "用户管理")])
                            }
                        }],
                        listData: [],
                        getList: {
                            PageIndex: 1,
                            PageSize: 10,
                            Sort: "ID",
                            SortDirection: 2
                        }
                    }
                },
                methods: {
                    toPath: function (t, e) {
                        console.log("test", t),
                        console.log("test2", e),
                        this.$router.push({
                            path: t
                        })
                    }
                },
                created: function () {
                    var t = this;
                    Object(a.l)("/ServiceInfo/SysList", this.getList).then(function (e) {
                        console.log("成功", e),
                            200 === e.status && e.data.Success ? (t.listData = e.data.Data) : t.toPath("/login")
                        //t.$local.save("Account", e.data.Data.Pager[0].Account), t.$emit("getAccount", e.data.Data.Pager[0].Account)
                    }).catch(function (t, e) {
                            console.log("失败", t)
                        })
                }
            },
            o = {
                render: function () {
                    var t = this.$createElement,
                        e = this._self._c || t;
                    return e("div", {
                        staticClass: "homeContainer"
                    },
                        [e("Table", {
                            attrs: {
                                border: "",
                                stripe: "",
                                columns: this.listColumns,
                                data: this.listData
                            }
                        }), this._v(" "), e("div", {
                            staticStyle: {
                                margin: "10px",
                                overflow: "hidden"
                            }
                        },
                            [e("div", {
                                staticStyle: {
                                    float: "right"
                                }
                            },
                                [e("Page", {
                                    attrs: {
                                        total: 100,
                                        current: 1
                                    }
                                })], 1)])], 1)
                },
                staticRenderFns: []
            };
        var i = n("VU/8")(r, o, !1,
            function (t) {
                n("c/Lf")
            },
            "data-v-4529e7e9", null);
        e.
            default = i.exports
    },
    "c/Lf": function (t, e) { }
});
//@ sourceMappingURL=3.6f6984121443ca356d31.js.map