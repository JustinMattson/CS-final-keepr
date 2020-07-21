import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true,
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    // privateKeeps: [],
    myKeeps: [],
    myVaults: [],
    activeKeep: {},
    activeVault: {},
  },
  mutations: {
    //#region mutation KEEPS
    setPublicKeeps(state, keeps) {
      state.publicKeeps = keeps;
    },
    // setPrivateKeeps(state, keeps) {
    //   state.privateKeeps = keeps;
    // },
    setUserKeeps(state, keeps) {
      state.myKeeps = keeps;
    },
    setActiveKeep(state, keep) {
      state.activeKeep = keep;
    },
    addKeep(state, newKeep) {
      state.myKeeps.push(newKeep);
    },
    updatePublicKeep(state, update) {
      let foundKeep = state.publicKeeps.find((k) => k.id == update.id);
      foundKeep = update;
    },
    updateMyKeep(state, update) {
      let foundKeep = state.myKeeps.find((k) => k.id == update.id);
      foundKeep = update;
    },
    // updatePrivateKeep(state, update) {
    //   let foundKeep = state.privateKeeps.find((k) => k.id == update.id);
    //   foundKeep = update;
    // },
    // removeKeep(state, id) {
    //   let index = state.privateKeeps.findIndex((k) => k.id == id);
    //   state.privateKeeps.splice(index, 1);
    // },
    //#endregion mutation KEEPS
    //#region mutation VAULTS
    setMyVaults(state, vaults) {
      state.myVaults = vaults;
    },
    addVault(state, newVault) {
      state.myVaults.push(newVault);
    },
    setActiveVault(state, vault) {
      state.activeVault = vault;
    },
    //#endregion mutation VAULTS
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    //#region actions KEEPS
    // getKeeps only returns isPrivate = false (Public)
    async getKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps");
        commit("setPublicKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    // getUserKeeps returns both private and public this specific user
    async getUserKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps/user");
        commit("setUserKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getKeepById({ commit, dispatch }, id) {
      try {
        let res = await api.get("keeps/" + id);
        commit("setActiveKeep", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async createKeep({ commit, dispatch }, newKeep) {
      try {
        let res = await api.post("keeps", newKeep);
        dispatch("getUserKeeps");
        commit("addKeep", res.data);
        commit("setActiveKeep", res.data);
        router.push({ name: "keepdetails", params: { keepId: res.data.id } });
        return res.data;
      } catch (error) {
        console.error(error);
      }
    },
    async editKeep({ commit, dispatch }, update) {
      try {
        let id = update.id;
        let res = await api.put("keeps/" + id, update);
        if (res.data.isPrivate == false) {
          commit("updatePublicKeep", res.data);
        } else {
          commit("updateMyKeep", res.data);
        }
      } catch (error) {
        console.error(error);
      }
    },
    async deleteKeep({ commit, dispatch }, id) {
      try {
        let res = await api.delete("keeps/" + id);
        commit("removeKeep", id);
      } catch (error) {
        console.error(error);
      }
    },
    //#endregion actions KEEPS
    //#region actions VAULTS
    async getUserVaults({ commit, dispatch }) {
      try {
        let res = await api.get("vaults");
        commit("setMyVaults", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async createVault({ commit, dispatch }, newVault) {
      try {
        let res = await api.post("vaults", newVault);
        dispatch("getUserVaults");
        commit("addVault", res.data);
        commit("setActiveVault", res.data);
        router.push({ name: "vaultdetails", params: { vaultId: res.data.id } });
        return res.data;
      } catch (error) {
        console.error(error);
      }
    },
    async getVaultById({ commit, dispatch }, id) {
      try {
        let res = await api.get("vaults/" + id);
        commit("setActiveVault", res.data);
      } catch (error) {
        console.error(error);
      }
    },

    //#endregion actions VAULTS
  },
});
